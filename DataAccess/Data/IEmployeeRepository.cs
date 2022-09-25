using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace DataAccess.Data
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes);
        Task<IEnumerable<Employee>> GetEmployeesInDepartmentAsync(string department, params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes);
        Task<Employee?> GetEmployeeAsync(Guid id, params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes);
        Task<Employee?> GetEmployeeByNameAsync(string name, params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes);
        Task<Employee?> GetEmployeeByCprNumberAsync(string cprNumber, params Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>[] includes);
        Task<Employee> InsertEmployeeAsync(AddEmployee addEmployee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Guid id);
    }
}
