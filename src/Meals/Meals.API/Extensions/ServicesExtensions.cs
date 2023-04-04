using Microsoft.EntityFrameworkCore;
using src.Meals.Meals.API.Helper;
using src.Meals.Meals.API.Repository;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Extensions
{
    public static class ServicesExtensions
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
        public static void ConfigureIngredientRepository(this IServiceCollection services)
        {
            services.AddScoped<IIngredientRepository, IngredientRepository>();
        }
        public static void ConfigureMealRepository(this IServiceCollection services)
        {
            services.AddScoped<IMealRepository, MealRepository>();
        }
    }
}