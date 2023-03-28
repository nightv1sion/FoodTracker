namespace src.ApiGateways.APIGateway.Services.Contracts;

public interface IProxyClient
{
    Task<string> DeleteToAsync(string url);
    Task<string> PutToAsync(string url, string body);
    Task<string> PostToAsync(string url, string body);
    Task<string> GetToAsync(string url);
}
