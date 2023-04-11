namespace src.WorkoutTracker.API.DataTransferObjects.Training;
public class CreateTrainingDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Guid> CompletedExercisesIds { get; set; }
}