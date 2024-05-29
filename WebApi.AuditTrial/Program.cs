using Microsoft.EntityFrameworkCore;
using WebApi.AuditTrial.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEntityFrameworkSqlServer();
var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContextPool<ProductsDbContext>((serviceProvider, optionsBuilder) =>
{
    optionsBuilder.UseSqlServer(connectionString);
    optionsBuilder.UseInternalServiceProvider(serviceProvider);
});

//builder.Services.AddDbContext<ProductsDbContext>((serviceProvider, options) =>
//{
//    options.UseSqlServer(Configuration["Database:ConnectionString"],
//    sqlServerOptionsAction: sqlOptions =>
//    {
//        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
//        sqlOptions.EnableRetryOnFailure(maxRetryCount: int.Parse(Configuration["Database:MaxRetryCount"])
//                                        , maxRetryDelay: TimeSpan.FromSeconds(int.Parse(Configuration["Database:MaxRetryDelaySeconds"]))
//                                        , errorNumbersToAdd: null);
//        sqlOptions.CommandTimeout(1800);
//    }).AddInterceptors(bool.Parse(Configuration["Database:UseMSIToAccessDB"]) ? serviceProvider.GetRequiredService<DbConnectionInterceptor>() : null);
//});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
