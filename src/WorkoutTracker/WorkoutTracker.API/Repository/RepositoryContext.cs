using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.Entities;

namespace src.WorkoutTracker.API.Repository;
public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {

    }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<CompletedExercise> CompletedExercises { get; set; }
    public DbSet<Training> Trainings { get; set; }
}