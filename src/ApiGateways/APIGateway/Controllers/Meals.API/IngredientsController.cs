using System.Text;
using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Controllers.Meals.API;

[Route("meals-api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly string _apiPath;
    private readonly IHttpRequestReader _requestReader;
    private readonly IStringContentCreator _contentCreator;
    private readonly IProxyClient _proxyClient;

    public IngredientsController(
        IConfiguration configuration,
        IHttpRequestReader requestReader,
        IStringContentCreator contentCreator,
        IProxyClient proxyClient)
    {
        _apiPath = configuration["MealsAPI:Ingredients"];
        _requestReader = requestReader;
        _contentCreator = contentCreator;
        _proxyClient = proxyClient;
    }

    [HttpGet]
    public async Task<ActionResult> GetIngredients()
    {
        return await _proxyClient.GetToAsync(_apiPath);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetIndredientById(Guid id)
    {
        return await _proxyClient.GetToAsync($"{_apiPath}/{id}");
    }

    [HttpPost]
    public async Task<ActionResult> CreateIngredient()
    {
        var body = await _requestReader.ReadRequestBodyAsync(Request);
        return await _proxyClient.PostToAsync(_apiPath, body);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateIngredient()
    {
        var body = await _requestReader.ReadRequestBodyAsync(Request);
        return await _proxyClient.PutToAsync(_apiPath, body);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteIngredient(Guid id)
    {
        return await _proxyClient.DeleteToAsync($"{_apiPath}/{id}");
    }
}