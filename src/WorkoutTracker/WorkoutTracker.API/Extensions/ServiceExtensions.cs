using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.Helper;
using src.WorkoutTracker.API.Repository;

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
}