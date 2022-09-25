using DataAccess.Models;
using System.Linq.Expressions;

namespace DataAccess.Data
{
    public interface IWorkTaskRepository
    {
        Task<IEnumerable<WorkTask>> GetWorkTaskAsync(params Expression<Func<WorkTask, object>>[] includes);
        Task<WorkTask?> GetWorkTaskAsync(Guid id, params Expression<Func<WorkTask, object>>[] includes);
        Task<WorkTask?> InsertWorkTaskAsync(AddWorkTask addWorkTask);
        Task UpdateWorkTaskAsync(WorkTask workTask);
        Task DeleteWorkTaskAsync(Guid id);
    }
}
