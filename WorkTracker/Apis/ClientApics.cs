using DataAccess.Data;
using DataAccess.Models;
using DataAccess.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace WorkTracker.Apis
{
    public static class ClientApi
    {
        public static void MapClientApi(this WebApplication app)
        {
            app.MapGet("/Clients", GetClients).WithTags("Client/customer management");
            app.MapGet("/Clients/{id}", GetClient).WithName("GetClientById").WithTags("Client/customer management");
            app.MapGet("/Clients/name/{id}", GetClientByName).WithTags("Client/customer management");
            app.MapPost("/Clients", InsertClient).WithTags("Client/customer management");
            //app.MapPut("/Clients", UpdateClient).WithTags("Client/customer management");
            //app.MapDelete("/Clients", DeleteClient).WithTags("Client/customer management");
        }

        [SwaggerOperation("List all clients/customers")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<ClientViewModel>))]
        private static async Task<IResult> GetClients(IClientRepository repository)
        {
            try
            {
                return Results.Ok((await repository.GetClientsAsync()).Select(n => new ClientViewModel(n)));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Get client/customer by id")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(ClientViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetClient(Guid id, IClientRepository repository)
        {
            try
            {
                var entity = await repository.GetClientAsync(id);
                if (entity == null) return Results.NotFound();
                return Results.Ok(new ClientViewModel(entity));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Get client/customer by name")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(ClientViewModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        private static async Task<IResult> GetClientByName(string id, IClientRepository repository)
        {
            try
            {
                var entity = await repository.GetClientByNameAsync(id);
                if (entity == null) return Results.NotFound();
                return Results.Ok(new ClientViewModel(entity));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [SwaggerOperation("Add client/customer")]
        [SwaggerResponse(StatusCodes.Status201Created)]
        private static async Task<IResult> InsertClient(AddClient addEntity, IClientRepository repository)
        {
            try
            {
                var entity = await repository.InsertClientAsync(addEntity);
                return Results.CreatedAtRoute("GetClientById", new { id = entity.Id });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        //[SwaggerOperation("Update client/customer")]
        //[SwaggerResponse(StatusCodes.Status200OK)]
        //private static async Task<IResult> UpdateClient(Client entity, IClientRepository repository)
        //{
        //    try
        //    {
        //        await repository.UpdateClientAsync(entity);
        //        return Results.Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Problem(ex.Message);
        //    }
        //}

        //[SwaggerOperation("Delete client/customer")]
        //[SwaggerResponse(StatusCodes.Status204NoContent)]
        //private static async Task<IResult> DeleteClient(Guid id, IClientRepository repository)
        //{
        //    try
        //    {
        //        await repository.DeleteClientAsync(id);
        //        return Results.NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Results.Problem(ex.Message);
        //    }
        //}
    }
}
