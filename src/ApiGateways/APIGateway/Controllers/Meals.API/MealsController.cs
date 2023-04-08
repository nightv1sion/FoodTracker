using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Controllers.Meals.API;
[Route("meals-api/[controller]")]
[ApiController]
public class MealsController : ControllerBase
{
    private readonly string _apiPath;
    private readonly IHttpRequestReader _requestReader;
    private readonly IStringContentCreator _contentCreator;
    private readonly IProxyClient _proxyClient;

    public MealsController(
        IConfiguration configuration,
        IHttpRequestReader requestReader,
        IStringContentCreator contentCreator,
        IProxyClient proxyClient)
    {
        _apiPath = configuration["MealsAPI:Meals"];
        _requestReader = requestReader;
        _contentCreator = contentCreator;
        _proxyClient = proxyClient;
    }

    [HttpGet]
    public async Task<ActionResult> GetMeals()
    {
        return await _proxyClient.GetToAsync(_apiPath);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetMealById(Guid id)
    {
        return await _proxyClient.GetToAsync($"{_apiPath}/{id}");
    }

    [HttpPost]
    public async Task<ActionResult> CreateMeal()
    {
        var body = await _requestReader.ReadRequestBodyAsync(Request);
        return await _proxyClient.PostToAsync(_apiPath, body);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateMeal()
    {
        var body = await _requestReader.ReadRequestBodyAsync(Request);
        return await _proxyClient.PutToAsync(_apiPath, body);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteMeal(Guid id)
    {
        return await _proxyClient.DeleteToAsync($"{_apiPath}/{id}");
    }
}