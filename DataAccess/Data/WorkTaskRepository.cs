using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Data
{
    public class WorkTaskRepository : IWorkTaskRepository
    {
        private readonly EmployeeDbContext _context;

        public WorkTaskRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task DeleteWorkTaskAsync(Guid id)
        {
            var entityToDelete = await _context.WorkTasks.FindAsync(id);
            if (entityToDelete == null)
                return;
            _context.WorkTasks.Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkTask>> GetWorkTaskAsync(params Expression<Func<WorkTask, object>>[] includes)
        {
            var query = _context.WorkTasks.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task<WorkTask?> GetWorkTaskAsync(Guid id, params Expression<Func<WorkTask, object>>[] includes)
        {
            var query = _context.WorkTasks.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<WorkTask?> InsertWorkTaskAsync(AddWorkTask addWorkTask)
        {
            if (!_context.Clients.Any(c => c.Id == addWorkTask.ClientId) || !_context.Clients.Any(c => c.Id == addWorkTask.EmployeeId))
            {
                return null;
            }

            var workTask = new WorkTask(addWorkTask);
            await _context.WorkTasks.AddAsync(workTask);
            await _context.SaveChangesAsync();
            return workTask;
        }

        public async Task UpdateWorkTaskAsync(WorkTask workTask)
        {
            _context.Entry(workTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
