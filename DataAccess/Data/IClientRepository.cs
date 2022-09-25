using DataAccess.Models;
using System.Linq.Expressions;

namespace DataAccess.Data
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync(params Expression<Func<Client, object>>[] includes);
        Task<Client?> GetClientAsync(Guid id, params Expression<Func<Client, object>>[] includes);
        Task<Client?> GetClientByNameAsync(string id, params Expression<Func<Client, object>>[] includes);
        Task<Client> InsertClientAsync(AddClient addClient);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(Guid id);
    }
}
