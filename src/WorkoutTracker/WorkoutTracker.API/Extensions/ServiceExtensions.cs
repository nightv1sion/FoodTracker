using System.Reflection;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.Helper;
using src.WorkoutTracker.API.Repository;
using src.WorkoutTracker.API.Repository.Contracts;
using src.WorkoutTracker.API.Service;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Extensions;
public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlServer(DatabaseConnectionHelper.GetConnectionString(configuration));
        });
    }
    public static void MigrateDatabase(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<RepositoryContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<ICompletedExerciseRepository, CompletedExerciseRepository>();
        services.AddScoped<ITrainingRepository, TrainingRepository>();
    }
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<ICompletedExerciseService, CompletedExerciseService>();
        services.AddScoped<ITrainingService, TrainingService>();
    }
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}