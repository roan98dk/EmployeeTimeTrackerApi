using DataAccess.Data;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace WorkTracker
{
    public static class Services
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x => 
            {
                x.EnableAnnotations();
                x.SwaggerDoc("v1", new()
                {
                    Title = "Work Tracking API",
                    Version = "v1",
                    Contact = new() { Name = "Ronnie Huang-Andreasen", Email = "roa@roa.dk" },
                    Description = "Plan employee work tasks, record completed ones and compare."
                });
            });
            
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Data related stuff
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
            builder.Services.AddScoped<IWorkTaskRepository, WorkTaskRepository>();
            builder.Services.AddDbContext<EmployeeDbContext>(
                options => options.UseInMemoryDatabase("EmployeeWorkPlannerDb"));
        }
    }
}
