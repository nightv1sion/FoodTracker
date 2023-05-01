using System.ComponentModel.DataAnnotations.Schema;

namespace src.ApiGateways.APIGateway.DataTransferObjects.WorkoutTracker.API;

public class UpdateCompletedExerciseDTO
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public Guid TrainingId { get; set; }
    [NotMapped]
    public int[] RepetitionCount { get; set; }
}