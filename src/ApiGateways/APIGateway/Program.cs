using src.ApiGateways.APIGateway.Extensions;
using src.ApiGateways.APIGateway.Services;
using src.ApiGateways.APIGateway.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.ConfigureHttpRequestReader();
builder.Services.ConfigureStringContentCreator();
builder.Services.ConfigureProxyClient();
builder.Services.ConfigureGrpcClients();

var app = builder.Build();

// Configure the HTTP request pipeline.
// app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
