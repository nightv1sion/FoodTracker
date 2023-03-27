using Microsoft.AspNetCore.Mvc;

namespace src.ApiGateways.APIGateway.Controllers;

[Route("[action]")]
[ApiController]
public class ProxyController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public ProxyController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    [HttpGet]
    public async Task<ActionResult> Ingredients()
        => await ProxyTo("http://host.docker.internal:5000/api/ingredient");

    private async Task<ContentResult> ProxyTo(string url)
        => Content(await _httpClient.GetStringAsync(url));
}