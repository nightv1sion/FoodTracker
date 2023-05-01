using System.Text.Json;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using src.ApiGateways.APIGateway.Interceptors;
using src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

namespace src.ApiGateways.APIGateway.Services.WorkoutTracker.API;

public class TrainingsGrpcClient : ITrainingsGrpcClient
{
    private readonly Trainings.TrainingsClient _client;
    public TrainingsGrpcClient(IConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration["WorkoutTrackerAPI"]);
        _client = new Trainings.TrainingsClient(channel.Intercept(new GrpcErrorHandlingInterceptor()));
    }

    public async Task<IEnumerable<TrainingProto>> GetTrainingsAsync()
    {
        var reply = await _client.GetTrainingsAsync(new GetTrainingsRequest());
        return reply.Trainings;
    }
    public async Task<TrainingProto> GetTrainingAsync(Guid id)
    {
        var reply = await _client.GetTrainingAsync(new GetTrainingRequest()
        {
            Id = id.ToString()
        });
        return reply.Training;
    }
    public async Task<TrainingProto> CreateTrainingAsync(CreateTrainingProto training)
    {
        var reply = await _client.CreateTrainingAsync(new CreateTrainingRequest()
        {
            Training = training
        });
        return reply.Training;
    }
    public async Task<TrainingProto> UpdateTrainingAsync(UpdateTrainingProto training)
    {
        var reply = await _client.UpdateTrainingAsync(new UpdateTrainingRequest()
        {
            Training = training
        });
        return reply.Training;
    }
    public async Task DeleteTrainingAsync(Guid id)
    {
        await _client.DeleteTrainingAsync(new DeleteTrainingRequest()
        {
            Id = id.ToString()
        });
    }
}