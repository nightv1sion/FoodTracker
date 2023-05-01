using System.ComponentModel.DataAnnotations.Schema;

namespace src.ApiGateways.APIGateway.DataTransferObjects.WorkoutTracker.API;

public class CreateCompletedExerciseDTO
{
    public Guid ExerciseId { get; set; }
    public Guid TrainingId { get; set; }
    [NotMapped]
    public int[] RepetitionCount { get; set; }
}