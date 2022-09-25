using WorkTracker;
using WorkTracker.Apis;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.CreateDatabaseAndInitialSeeding();

app.MapApis();

app.Run();
