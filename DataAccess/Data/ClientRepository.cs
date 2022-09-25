using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly EmployeeDbContext _context;

        public ClientRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task DeleteClientAsync(Guid id)
        {
            var clientToDelete = await _context.Clients.FindAsync(id);
            if (clientToDelete == null)
                return;
            _context.Clients.Remove(clientToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Client?> GetClientAsync(Guid id, params Expression<Func<Client, object>>[] includes)
        {
            var query = _context.Clients.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Client?> GetClientByNameAsync(string id, params Expression<Func<Client, object>>[] includes)
        {
            var query = _context.Clients.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync(p => p.Name.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<IEnumerable<Client>> GetClientsAsync(params Expression<Func<Client, object>>[] includes)
        {
            var query = _context.Clients.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task<Client> InsertClientAsync(AddClient addClient)
        {
            var client = new Client(addClient);
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task UpdateClientAsync(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
