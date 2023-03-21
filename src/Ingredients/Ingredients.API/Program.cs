using System.Reflection;
using MediatR;
using src.Ingredients.Ingredients.API.Extensions;
using src.Ingredients.Ingredients.API.Helper;
using src.Ingredients.Ingredients.API.Repository;
using src.Ingredients.Ingredients.API.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddMediatR(
    config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
// builder.Services.MigrateDatabase();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
