using Microsoft.AspNetCore.Mvc;
using src.WorkoutTracker.API.DataTransferObjects.Exercise;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ExercisesController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExercisesController(
        IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetExercises()
    {
        var exercises = await _exerciseService.GetExercisesAsync(false);
        return Ok(exercises);
    }
    [HttpGet("{id:guid}", Name = "GetExerciseById")]
    public async Task<IActionResult> GetExerciseById(Guid id)
    {
        var exercise = await _exerciseService.GetExerciseAsync(id, false);
        return Ok(exercise);
    }
    [HttpPost]
    public async Task<IActionResult> CreateExercise(CreateExerciseDTO dto)
    {
        var exercise = await _exerciseService.CreateExerciseAsync(dto);
        return CreatedAtRoute("GetExerciseById", new { Id = exercise.Id }, exercise);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateExercise(UpdateExerciseDTO dto)
    {
        var exercise = await _exerciseService.UpdateExerciseAsync(dto);
        return Ok(exercise);
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteExercise(Guid id)
    {
        await _exerciseService.DeleteExerciseAsync(id);
        return Ok();
    }

}