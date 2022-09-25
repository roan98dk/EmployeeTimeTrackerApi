using DataAccess.Data;
using DataAccess.Models;
using DataAccess.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace WorkTracker.Apis
{
    public static class WorkTaskApi
    {
        public static void MapWorkTaskApi(this WebApplication app)
        {
            app.MapGet("/WorkTasks", GetAllWorkTasks).WithTags("Work task management");
            app.MapGet("/WorkTasks/{id}", GetWorkTask).WithName("GetWorkTaskById").WithTags("Work task management");
            app.MapPost("/WorkTasks", InsertWorkTask).WithTags("Work task management");
            //app.MapPut("/WorkTasks", UpdateWorkTask).WithTags("Work task management");
            //app.MapDelete("/WorkTasks", DeleteWorkTask).WithTags("Work task management");
        }

        [SwaggerOperation("List all work tasks")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<WorkTaskViewModel>))]
        private static async Task<IResult> GetAllWorkTasks(IWorkTaskRepository repository)
        {
            try
            {
                return Results.Ok((await repository.GetWorkTaskAsync(p => p.Employee, p => p.Client)).Select(n => new WorkTaskViewModel(n)));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Get work task by id")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(WorkTaskViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetWorkTask(Guid id, IWorkTaskRepository repository)
        {
            try
            {
                var entity = await repository.GetWorkTaskAsync(id, p => p.Employee, p => p.Client);
                if (entity == null) return Results.NotFound();
                return Results.Ok(new WorkTaskViewModel(entity));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Add work task")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        private static async Task<IResult> InsertWorkTask(AddWorkTask addEntity, IWorkTaskRepository repository)
        {
            try
            {
                var entity = await repository.InsertWorkTaskAsync(addEntity);
                if (entity == null) return Results.BadRequest();
                return Results.CreatedAtRoute("GetWorkTaskById", new { id = entity.Id });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        //[SwaggerOperation("Update work task")]
        //[SwaggerResponse(StatusCodes.Status200OK)]
        //private static async Task<IResult> UpdateWorkTask(WorkTask entity, IWorkTaskRepository repository)
        //{
        //    try
        //    {
        //        await repository.UpdateWorkTaskAsync(entity);
        //        return Results.Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Problem(ex.Message);
        //    }
        //}

        //private static async Task<IResult> DeleteWorkTask(Guid id, IWorkTaskRepository repository)
        //{
        //    try
        //    {
        //        await repository.DeleteWorkTaskAsync(id);
        //        return Results.NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Problem(ex.Message);
        //    }
        //}
    }
}
