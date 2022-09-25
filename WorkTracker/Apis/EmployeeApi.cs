using DataAccess.Data;
using DataAccess.Models;
using DataAccess.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace WorkTracker.Apis
{
    public static class EmployeeApi
    {
        public static void MapEmployeeApi(this WebApplication app)
        {
            app.MapGet("/Employees", GetEmployees).WithTags("Employee management");
            app.MapGet("/Employees/{id}", GetEmployee).WithName("GetEmployeeById").WithTags("Employee management");
            app.MapPost("/Employees", InsertEmployee).WithTags("Employee management");
            //app.MapPut("/Employees", UpdateEmployee).WithTags("Employee management");
            //app.MapDelete("/Employees", DeleteEmployee).WithTags("Employee management");
        }

        [SwaggerOperation("List all employess")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<EmployeeViewModel>))]
        private static async Task<IResult> GetEmployees(IEmployeeRepository repository)
        {
            try
            {
                return Results.Ok((await repository.GetEmployeesAsync()).Select(n => new EmployeeViewModel(n)));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Get employee by id")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(EmployeeViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetEmployee(Guid id, IEmployeeRepository repository)
        {
            try
            {
                var entity = await repository.GetEmployeeAsync(id);
                if (entity == null) return Results.NotFound();
                return Results.Ok(new EmployeeViewModel(entity));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Add employee")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        private static async Task<IResult> InsertEmployee(AddEmployee addEntity, IEmployeeRepository repository)
        {
            try
            {
                var entity = await repository.InsertEmployeeAsync(addEntity);
                return Results.CreatedAtRoute("GetEmployeeById", new { id = entity.Id });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        
        //[SwaggerOperation("Update employee")]
        //[SwaggerResponse(StatusCodes.Status200OK)]
        //private static async Task<IResult> UpdateEmployee(Employee entity, IEmployeeRepository repository)
        //{
        //    try
        //    {
        //        await repository.UpdateEmployeeAsync(entity);
        //        return Results.Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Problem(ex.Message);
        //    }
        //}

        //[SwaggerOperation("Delete employee")]
        //[SwaggerResponse(StatusCodes.Status204NoContent)]
        //private static async Task<IResult> DeleteEmployee(Guid id, IEmployeeRepository repository)
        //{
        //    try
        //    {
        //        await repository.DeleteEmployeeAsync(id);
        //        return Results.NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Problem(ex.Message);
        //    }
        //}
    }
}
