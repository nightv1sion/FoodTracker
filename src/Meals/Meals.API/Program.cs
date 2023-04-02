using System.Reflection;
using src.Meals.Meals.API.Extensions;
using src.Meals.Meals.API.Middlewares;
using src.Meals.Meals.API.Repository;
using src.Meals.Meals.API.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddMediatR(
    config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.MigrateDatabase();
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
app.UseMiddleware<MediatorErrorHandlingMiddleware>();
app.MapControllers();

app.Run();
