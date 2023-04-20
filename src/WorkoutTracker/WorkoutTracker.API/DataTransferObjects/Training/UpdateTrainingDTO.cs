namespace src.WorkoutTracker.API.DataTransferObjects.Training;
public class UpdateTrainingDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Guid> CompletedExercisesIds { get; set; }
}