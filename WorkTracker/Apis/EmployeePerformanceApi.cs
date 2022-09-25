using DataAccess.Data;
using DataAccess.ViewModels;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace WorkTracker.Apis
{
    public static class EmployeePerformanceApi
    {
        public static void MapEmployeePerformanceApi(this WebApplication app)
        {
            app.MapGet("/EmployeePerformance", GetEmployees).WithTags("Employee performance");
            app.MapGet("/EmployeePerformance/{id:guid}", GetEmployee).WithTags("Employee performance");
            app.MapGet("/EmployeePerformance/name/{id}", GetEmployeeByName).WithTags("Employee performance");
            app.MapGet("/EmployeePerformance/cpr/{id}", GetEmployeeByCprNumber).WithTags("Employee performance");
        }

        [SwaggerOperation("Get performance for all employees in a given month")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<EmployeePerformanceViewModel>))]
        private static async Task<IResult> GetEmployees(int month, int year, IEmployeeRepository repository)
        {
            try
            {
                return Results.Ok((await repository.GetEmployeesAsync(e => e.Include(w => w.WorkTasks).ThenInclude(c => c.Client)))
                    .Select(n => new EmployeePerformanceViewModel(n, month, year))
                    .Where(p => p.WorkHoursPlanned > 0 || p.WorkHoursCompleted > 0));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Get performance for a single employee in a given month. Query by id.")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(EmployeePerformanceViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetEmployee(Guid id, int month, int year, IEmployeeRepository repository)
        {
            try
            {
                var entity = await repository.GetEmployeeAsync(id, e => e.Include(w => w.WorkTasks).ThenInclude(c => c.Client));
                if (entity == null) return Results.NotFound();
                return Results.Ok(new EmployeePerformanceViewModel(entity, month, year));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Get performance for a single employee in a given month. Query by name.")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(EmployeePerformanceViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetEmployeeByName(string id, int month, int year, IEmployeeRepository repository)
        {
            try
            {
                var entity = await repository.GetEmployeeByNameAsync(id, e => e.Include(w => w.WorkTasks).ThenInclude(c => c.Client));
                if (entity == null) return Results.NotFound();
                return Results.Ok(new EmployeePerformanceViewModel(entity, month, year));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Get performance for a single employee in a given month. Query by Danish CPR number.")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(EmployeePerformanceViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetEmployeeByCprNumber(string id, int month, int year, IEmployeeRepository repository)
        {
            try
            {
                var entity = await repository.GetEmployeeByCprNumberAsync(id, e => e.Include(w => w.WorkTasks).ThenInclude(c => c.Client));
                if (entity == null) return Results.NotFound();
                return Results.Ok(new EmployeePerformanceViewModel(entity, month, year));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
