using System.Text;
using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.Services.Contracts;
using src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

namespace src.ApiGateways.APIGateway.Controllers.WorkoutTracker.API;

[Route("workouttracker-api/[controller]")]
[ApiController]
public class TrainingsController : ControllerBase
{
    private readonly ITrainingsGrpcClient _trainingGrpcClient;

    public TrainingsController(
        ITrainingsGrpcClient trainingGrpcClient
        )
    {
        _trainingGrpcClient = trainingGrpcClient;
    }

    [HttpGet]
    public async Task<ActionResult> GetTrainings()
    {
        var trainings = await _trainingGrpcClient.GetTrainingsAsync();
        return Ok(trainings);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetTrainingById(Guid id)
    {
        var training = await _trainingGrpcClient.GetTrainingAsync(id);
        return Ok(training);
    }
    [HttpPost]
    public async Task<ActionResult> CreateTraining(CreateTrainingProto trainingProto)
    {
        var training = await _trainingGrpcClient.CreateTrainingAsync(trainingProto);
        return Ok(training);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateTraining(UpdateTrainingProto trainingProto)
    {
        var training = await _trainingGrpcClient.UpdateTrainingAsync(trainingProto);
        return Ok(training);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteTraining(Guid id)
    {
        await _trainingGrpcClient.DeleteTrainingAsync(id);
        return Ok();
    }
}