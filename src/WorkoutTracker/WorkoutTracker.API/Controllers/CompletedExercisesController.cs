using Microsoft.AspNetCore.Mvc;
using src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CompletedExercisesController : ControllerBase
{
    private readonly ICompletedExerciseService _completedExerciseService;

    public CompletedExercisesController(
        ICompletedExerciseService completedExerciseService)
    {
        _completedExerciseService = completedExerciseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompletedExercises()
    {
        var completedExercises = await _completedExerciseService.GetCompletedExercisesAsync(false);
        return Ok(completedExercises);
    }
    [HttpGet("{id:guid}", Name = "GetCompletedExerciseById")]
    public async Task<IActionResult> GetCompletedExerciseById(Guid id)
    {
        var completedExercise = await _completedExerciseService.GetCompletedExerciseAsync(id, false);
        return Ok(completedExercise);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCompletedExercise(CreateCompletedExerciseDTO dto)
    {
        var completedExercise = await _completedExerciseService.CreateCompletedExerciseAsync(dto);
        return CreatedAtRoute("GetCompletedExerciseById", new { Id = completedExercise.Id }, completedExercise);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCompletedExercise(UpdateCompletedExerciseDTO dto)
    {
        var completedExercise = await _completedExerciseService.UpdateCompletedExerciseAsync(dto);
        return Ok(completedExercise);
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCompletedExercise(Guid id)
    {
        await _completedExerciseService.DeleteCompletedExerciseAsync(id);
        return Ok();
    }

}