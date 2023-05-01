using Grpc.Net.Client;
using src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;
using src.ApiGateways.APIGateway.DataTransferObjects.WorkoutTracker.API;

namespace src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

public interface ICompletedExercisesGrpcClient
{
    Task<IEnumerable<CompletedExerciseProto>> GetCompletedExercisesAsync();
    Task<CompletedExerciseProto> GetCompletedExerciseAsync(Guid id);
    Task<CompletedExerciseProto> CreateCompletedExerciseAsync(CreateCompletedExerciseDTO completedExercise);
    Task<CompletedExerciseProto> UpdateCompletedExerciseAsync(UpdateCompletedExerciseDTO completedExercise);
    Task DeleteCompletedExerciseAsync(Guid id);

}