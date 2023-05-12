using CRUD.EFCore.Net6.API.Helpers;
using CRUD.EFCore.Net6.API.Repository.Interface;
using CRUD.EFCore.Net6.API.Repository.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    //builder.Services.AddControllers();
    //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();

    var services = builder.Services;
    var env = builder.Environment;

    services.AddDbContext<DataContext>();
    services.AddCors();
    services.AddControllers().AddJsonOptions(json =>
    {
        json.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        json.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    
    services.AddSwaggerGen();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddScoped<IUserService, UserService>();
}
var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors(cors => cors
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

    app.UseMiddleware<ErrorHandlerMiddleware>();
    app.MapControllers();

    // app.UseHttpsRedirection();
    //  app.UseAuthorization();
}

app.Run();
