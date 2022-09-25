using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DataAccess.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var entityToDelete = await _context.Employees.FindAsync(id);
            if (entityToDelete == null)
                return;
            _context.Employees.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee?> GetEmployeeAsync(Guid id, params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes)
        {
            var query = _context.Employees.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => include(current));
            }
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Employee?> GetEmployeeByCprNumberAsync(string cprNumber, params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes)
        {
            var query = _context.Employees.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => include(current));
            }
            return await query.FirstOrDefaultAsync(p => p.CprNumber.Equals(cprNumber, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Employee?> GetEmployeeByNameAsync(string name, params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes)
        {
            var query = _context.Employees.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => include(current));
            }
            return await query.FirstOrDefaultAsync(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes)
        {
            var query = _context.Employees.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => include(current));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesInDepartmentAsync(string department, params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes)
        {
            var query = _context.Employees.Where(e => e.Department.Equals(department, StringComparison.OrdinalIgnoreCase));
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => include(current));
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> InsertEmployeeAsync(AddEmployee addEmployee)
        {
            var employee = new Employee(addEmployee);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
