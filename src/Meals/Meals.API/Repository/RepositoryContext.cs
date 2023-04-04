using Microsoft.EntityFrameworkCore;
using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Calories)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Proteins)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Carbs)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Fats)
                .HasColumnType("decimal(18, 2)");
        }
    }
}