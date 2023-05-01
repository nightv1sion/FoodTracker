using Grpc.Net.Client;
using src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;

namespace src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

public interface ITrainingsGrpcClient
{
    Task<IEnumerable<TrainingProto>> GetTrainingsAsync();
    Task<TrainingProto> GetTrainingAsync(Guid id);
    Task<TrainingProto> CreateTrainingAsync(CreateTrainingProto training);
    Task<TrainingProto> UpdateTrainingAsync(UpdateTrainingProto training);
    Task DeleteTrainingAsync(Guid id);

}