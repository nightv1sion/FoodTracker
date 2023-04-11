using Microsoft.AspNetCore.Mvc;
using src.WorkoutTracker.API.DataTransferObjects.Training;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TrainingsController : ControllerBase
{
    private readonly ITrainingService _trainingService;

    public TrainingsController(
        ITrainingService trainingService)
    {
        _trainingService = trainingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTrainings()
    {
        var trainings = await _trainingService.GetTrainingsAsync(false);
        return Ok(trainings);
    }
    [HttpGet("{id:guid}", Name = "GetTrainingById")]
    public async Task<IActionResult> GetTrainingById(Guid id)
    {
        var training = await _trainingService.GetTrainingAsync(id, false);
        return Ok(training);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTraining(CreateTrainingDTO dto)
    {
        var training = await _trainingService.CreateTrainingAsync(dto);
        return CreatedAtRoute("GetTrainingById", new { Id = training.Id }, training);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateTraining(UpdateTrainingDTO dto)
    {
        var training = await _trainingService.UpdateTrainingAsync(dto);
        return Ok(training);
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTraining(Guid id)
    {
        await _trainingService.DeleteTrainingAsync(id);
        return Ok();
    }

}