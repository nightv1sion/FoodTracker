using Microsoft.AspNetCore.Mvc;

namespace src.ApiGateways.APIGateway.Services.Contracts;

public interface IProxyClient
{
    Task<ActionResult> DeleteToAsync(string url);
    Task<ActionResult> PutToAsync(string url, string body);
    Task<ActionResult> PostToAsync(string url, string body);
    Task<ActionResult> GetToAsync(string url);
}
