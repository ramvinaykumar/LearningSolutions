using Microsoft.EntityFrameworkCore;
using ATS.EFCore.DBFirst.API.Models;
using ATS.EFCore.DBFirst.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEntityFrameworkSqlServer();
var connectionString = builder.Configuration.GetConnectionString("DBConeection");
builder.Services.AddDbContextPool<LearningContext>((serviceProvider, optionsBuilder) =>
{
    optionsBuilder.UseSqlServer(connectionString);
    optionsBuilder.UseInternalServiceProvider(serviceProvider);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseAuthorization();

app.MapControllers();

app.Run();
