using EmployeeTimeTracker.Data;
using EmployeeTimeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimeTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;

        public ClientController(EmployeeDbContext dbContext) => _dbContext = dbContext;

        // GET: api/Client
        [HttpGet]
        public async Task<IEnumerable<Client>> Get() => await _dbContext.Clients.ToListAsync();

        // GET api/Client/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var client = await _dbContext.Clients.FindAsync(id);
            return client == null ? NotFound() : Ok(client);
        }

        // POST api/Client
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(AddClient addClient)
        {
            var client = new Client(addClient);
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
        }

        // PUT api/Client/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, Client client)
        {
            if (id != client.Id) return BadRequest();

            _dbContext.Entry(client).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/Client/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var clientToDelete = await _dbContext.Clients.FindAsync(id);
            if (clientToDelete == null) return NotFound();

            _dbContext.Clients.Remove(clientToDelete);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
