using DataAccess.Data;
using DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace WorkTracker.Apis
{
    public static class DepartmentPerformanceApi
    {
        public static void MapDepartmentPerformanceApi(this WebApplication app)
        {
            app.MapGet("/DepartmentPerformance", GetDepartments).WithTags("Department performance");
            app.MapGet("/DepartmentPerformance/{department}", GetDepartment).WithTags("Department performance");
        }

        [SwaggerOperation("Get performance for all departments in a given month")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<EmployeePerformanceViewModel>))]
        private static async Task<IResult> GetDepartments(int month, int year, IEmployeeRepository repository)
        {
            try
            {
                var departments = (await repository.GetEmployeesAsync(e => e.Include(w => w.WorkTasks).ThenInclude(c => c.Client)))
                    .Select(n => new DepartmentPerformanceViewModel(n, month, year))
                    .GroupBy(n => n.Department)
                    .Select(n => new DepartmentPerformanceViewModel(n.Key, month, year) { ExpectedIncome = n.Sum(t => t.ExpectedIncome), ActualIncome = n.Sum(t => t.ActualIncome), WorkHoursPlanned = n.Sum(t => t.WorkHoursPlanned), WorkHoursCompleted = n.Sum(t => t.WorkHoursCompleted)}).ToList();
                return Results.Ok(departments);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Get performance for a single department in a given month")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(EmployeePerformanceViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetDepartment(string department, int month, int year, IEmployeeRepository repository)
        {
            try
            {
                var departments = (await repository.GetEmployeesInDepartmentAsync(department, e => e.Include(w => w.WorkTasks).ThenInclude(c => c.Client)))
                    .Select(n => new DepartmentPerformanceViewModel(n, month, year))
                    .GroupBy(n => n.Department)
                    .Select(n => new DepartmentPerformanceViewModel(n.Key, month, year) { ExpectedIncome = n.Sum(t => t.ExpectedIncome), ActualIncome = n.Sum(t => t.ActualIncome), WorkHoursPlanned = n.Sum(t => t.WorkHoursPlanned), WorkHoursCompleted = n.Sum(t => t.WorkHoursCompleted) }).FirstOrDefault();
                return Results.Ok(departments);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
