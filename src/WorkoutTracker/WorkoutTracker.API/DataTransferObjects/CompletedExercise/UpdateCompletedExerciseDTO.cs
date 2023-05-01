namespace src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
public class UpdateCompletedExerciseDTO
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public int[] RepetitionCount { get; set; }
    public Guid TrainingId { get; set; }
}