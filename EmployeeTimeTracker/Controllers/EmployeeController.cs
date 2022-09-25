using EmployeeTimeTracker.Data;
using EmployeeTimeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimeTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeController(EmployeeDbContext dbContext) => _dbContext = dbContext;

        // GET: api/Employee
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get() => await _dbContext.Employees.ToListAsync();

        // GET api/Employee/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }

        // POST api/Employee
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(AddEmployee addEmployee)
        {
            var employee = new Employee(addEmployee);
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();

            _dbContext.Entry(employee).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employeeToDelete = await _dbContext.Employees.FindAsync(id);
            if (employeeToDelete == null) return NotFound();

            _dbContext.Employees.Remove(employeeToDelete);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
