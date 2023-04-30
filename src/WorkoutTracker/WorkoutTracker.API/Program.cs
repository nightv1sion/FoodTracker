using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.Extensions;
using src.WorkoutTracker.API.Intereptors;
using src.WorkoutTracker.API.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureHttp1AndHttp2();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.MigrateDatabase();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();
builder.Services.ConfigureAutoMapper();
builder.Services.AddGrpcSwagger();
builder.Services.AddGrpc(x => x.Interceptors.Add<GrpcGlobalExceptionHandlerInterceptor>());
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("swagger/v1/swagger.json", "API v1");
});

// app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGlobalErrorHandling();

app.MapControllers();

app.MapGrpcServices();

app.Run();
