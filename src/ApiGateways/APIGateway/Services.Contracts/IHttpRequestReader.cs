namespace src.ApiGateways.APIGateway.Services.Contracts;

public interface IHttpRequestReader
{
    Task<string> ReadRequestBodyAsync(HttpRequest request);
}
