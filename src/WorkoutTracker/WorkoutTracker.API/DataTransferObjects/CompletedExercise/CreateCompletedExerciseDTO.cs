namespace src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
public class CreateCompletedExerciseDTO
{
    public Guid ExerciseId { get; set; }
    public int[] RepetitionCountArray { get; set; }
    public Guid TrainingId { get; set; }
}