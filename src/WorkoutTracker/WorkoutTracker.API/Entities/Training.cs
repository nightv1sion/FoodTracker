namespace src.WorkoutTracker.API.Entities;
public class Training
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<CompletedExercise> CompletedExercises { get; set; }
}