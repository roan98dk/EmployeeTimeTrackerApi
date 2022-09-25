using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
    }
}
