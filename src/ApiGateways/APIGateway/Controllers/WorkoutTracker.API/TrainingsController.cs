using System.Text;
using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Controllers.WorkoutTracker.API;

[Route("workouttracker-api/[controller]")]
[ApiController]
public class TrainingsController : ControllerBase
{
    private readonly string _apiPath;
    private readonly IHttpRequestReader _requestReader;
    private readonly IStringContentCreator _contentCreator;
    private readonly IProxyClient _proxyClient;

    public TrainingsController(
        IConfiguration configuration,
        IHttpRequestReader requestReader,
        IStringContentCreator contentCreator,
        IProxyClient proxyClient)
    {
        _apiPath = configuration["WorkoutTrackerAPI:Trainings"];
        _requestReader = requestReader;
        _contentCreator = contentCreator;
        _proxyClient = proxyClient;
    }

    [HttpGet]
    public async Task<ActionResult> GetTrainings()
    {
        return await _proxyClient.GetToAsync(_apiPath);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetTrainingById(Guid id)
    {
        return await _proxyClient.GetToAsync($"{_apiPath}/{id}");
    }

    [HttpPost]
    public async Task<ActionResult> CreateTraining()
    {
        var body = await _requestReader.ReadRequestBodyAsync(Request);
        return await _proxyClient.PostToAsync(_apiPath, body);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateTraining()
    {
        var body = await _requestReader.ReadRequestBodyAsync(Request);
        return await _proxyClient.PutToAsync(_apiPath, body);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteTraining(Guid id)
    {
        return await _proxyClient.DeleteToAsync($"{_apiPath}/{id}");
    }
}