using Grpc.Net.Client;
using src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;

namespace src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

public interface IExercisesGrpcClient
{
    Task<IEnumerable<ExerciseProto>> GetExercisesAsync();
    Task<ExerciseProto> GetExerciseAsync(Guid id);
    Task<ExerciseProto> CreateExerciseAsync(CreateExerciseProto exercise);
    Task<ExerciseProto> UpdateExerciseAsync(UpdateExerciseProto exercise);
    Task DeleteExerciseAsync(Guid id);

}