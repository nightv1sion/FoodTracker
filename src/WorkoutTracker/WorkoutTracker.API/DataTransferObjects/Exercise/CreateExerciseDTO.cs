namespace src.WorkoutTracker.API.DataTransferObjects.Exercise;
public class CreateExerciseDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Calories { get; set; }
}