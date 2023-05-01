using System.Text;
using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.Services.Contracts;
using src.ApiGateways.APIGateway.Services.Contracts.FoodTracker.API;
using src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

namespace src.ApiGateways.APIGateway.Controllers.WorkoutTracker.API;

[Route("workouttracker-api/[controller]")]
[ApiController]
public class ExercisesController : ControllerBase
{
    private readonly IExercisesGrpcClient _exerciseGrpcClient;

    public ExercisesController(
        IExercisesGrpcClient exerciseGrpcClient
        )
    {
        _exerciseGrpcClient = exerciseGrpcClient;
    }

    [HttpGet]
    public async Task<ActionResult> GetExercises()
    {
        var exercises = await _exerciseGrpcClient.GetExercisesAsync();
        return Ok(exercises);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetExerciseById(Guid id)
    {
        var exercise = await _exerciseGrpcClient.GetExerciseAsync(id);
        return Ok(exercise);
    }
    [HttpPost]
    public async Task<ActionResult> CreateExercise(CreateExerciseProto exerciseProto)
    {
        var exercise = await _exerciseGrpcClient.CreateExerciseAsync(exerciseProto);
        return Ok(exercise);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateExercise(UpdateExerciseProto exerciseProto)
    {
        var exercise = await _exerciseGrpcClient.UpdateExerciseAsync(exerciseProto);
        return Ok(exercise);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteExercise(Guid id)
    {
        await _exerciseGrpcClient.DeleteExerciseAsync(id);
        return Ok();
    }
}