using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Services
{
    public class HttpRequestReader : IHttpRequestReader 
    {
        public async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            string body = null;
            using (var reader = new StreamReader(request.Body))
            {
                body = await reader.ReadToEndAsync();
            }

            return body;
        }
    }
}