using Learning.DBFirst.EFCore.API.Data;
using Learning.DBFirst.EFCore.API.Repository.Interface;
using Learning.DBFirst.EFCore.API.Repository.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};




builder.Services.AddEntityFrameworkSqlServer();
var connectionString = builder.Configuration.GetConnectionString("DBConeection");
builder.Services.AddDbContextPool<MyDbContext>((serviceProvider, optionsBuilder) =>
{
    optionsBuilder.UseSqlServer(connectionString);
    optionsBuilder.UseInternalServiceProvider(serviceProvider);
});

// Add services to the container.
builder.Services.AddScoped<ICake, CakeDataService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}