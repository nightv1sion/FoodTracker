namespace src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
public class CompletedExerciseDTO
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public int[] RepetitionCountArray { get; set; }
    public Guid TrainingId { get; set; }
}