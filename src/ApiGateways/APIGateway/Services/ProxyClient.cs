using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Services
{
    public class ProxyClient : IProxyClient
    {
        private readonly IStringContentCreator _contentCreator;
        private readonly HttpClient _httpClient;

        public ProxyClient(
            IStringContentCreator contentCreator,
            IHttpClientFactory clientFactory)
        {
            _contentCreator = contentCreator;
            _httpClient = clientFactory.CreateClient();
        }
        public async Task<string> DeleteToAsync(string url)
        {
            var result = await _httpClient.DeleteAsync(url);
            return await result.Content.ReadAsStringAsync();
        }
        public async Task<string> PutToAsync(string url, string body)
        {
            var content = _contentCreator.CreateContent(body);
            var result = await _httpClient.PutAsync(url, content);
            return await result.Content.ReadAsStringAsync();
        }
        public async Task<string> PostToAsync(string url, string body)
        {
            var content = _contentCreator.CreateContent(body);
            var result = await _httpClient.PostAsync(url, content);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetToAsync(string url)
            => await _httpClient.GetStringAsync(url);
    }
}