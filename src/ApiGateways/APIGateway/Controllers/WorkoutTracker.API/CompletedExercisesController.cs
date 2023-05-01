using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.DataTransferObjects.WorkoutTracker.API;
using src.ApiGateways.APIGateway.Services.Contracts;
using src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

namespace src.ApiGateways.APIGateway.Controllers.WorkoutTracker.API;

[Route("workouttracker-api/[controller]")]
[ApiController]
public class CompletedExercisesController : ControllerBase
{
    private readonly ICompletedExercisesGrpcClient _completedExerciseGrpcClient;

    public CompletedExercisesController(
        ICompletedExercisesGrpcClient completedExerciseGrpcClient
        )
    {
        _completedExerciseGrpcClient = completedExerciseGrpcClient;
    }

    [HttpGet]
    public async Task<ActionResult> GetCompletedExercises()
    {
        var completedExercises = await _completedExerciseGrpcClient.GetCompletedExercisesAsync();
        return Ok(completedExercises);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetCompletedExerciseById(Guid id)
    {
        var completedExercise = await _completedExerciseGrpcClient.GetCompletedExerciseAsync(id);
        return Ok(completedExercise);
    }
    [HttpPost]
    public async Task<ActionResult> CreateCompletedExercise(
        CreateCompletedExerciseDTO dto)
    {
        var completedExercise = await _completedExerciseGrpcClient.CreateCompletedExerciseAsync(
            dto);
        return Ok(completedExercise);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCompletedExercise(UpdateCompletedExerciseDTO dto)
    {
        var completedExercise = await _completedExerciseGrpcClient.UpdateCompletedExerciseAsync(dto);
        return Ok(completedExercise);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteCompletedExercise(Guid id)
    {
        await _completedExerciseGrpcClient.DeleteCompletedExerciseAsync(id);
        return Ok();
    }
}