namespace src.WorkoutTracker.API.DataTransferObjects.Exercise;
public class UpdateExerciseDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Calories { get; set; }
}