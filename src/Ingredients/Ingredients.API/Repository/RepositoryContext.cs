using Microsoft.EntityFrameworkCore;

namespace src.Ingredients.Ingredients.API.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Calories)
                .HasColumnType("decimal(10, 8)");

            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Proteins)
                .HasColumnType("decimal(10, 8)");

            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Carbs)
                .HasColumnType("decimal(10, 8)");

            modelBuilder.Entity<Ingredient>()
                .Property(x => x.Fats)
                .HasColumnType("decimal(10, 8)");
        }
    }
}