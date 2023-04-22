using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public async Task<ActionResult> DeleteToAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            return await GetActionResult(response);
        }
        public async Task<ActionResult> PutToAsync(string url, string body)
        {
            var content = _contentCreator.CreateContent(body);
            var response = await _httpClient.PutAsync(url, content);
            return await GetActionResult(response);
        }
        public async Task<ActionResult> PostToAsync(string url, string body)
        {
            var content = _contentCreator.CreateContent(body);
            var response = await _httpClient.PostAsync(url, content);
            return await GetActionResult(response);
        }

        public async Task<ActionResult> GetToAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await GetActionResult(response);
        }

        private async Task<ActionResult> GetActionResult(HttpResponseMessage response)
        {
            ActionResult result = null;
            var responseContent = await response.Content.ReadAsStringAsync();

            string content = null;
            try
            {
                content = JsonConvert.SerializeObject(
                    JsonConvert.DeserializeObject(responseContent), Formatting.Indented);
            }
            catch
            {
                content = responseContent;
            }
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    result = new OkObjectResult(content); break;
                case System.Net.HttpStatusCode.NoContent:
                    result = new OkResult(); break;
                case System.Net.HttpStatusCode.Created:
                    result = new OkObjectResult(content); break;
                case System.Net.HttpStatusCode.NotFound:
                    result = new NotFoundObjectResult(content); break;
                case System.Net.HttpStatusCode.Unauthorized:
                    result = new UnauthorizedObjectResult(content); break;
                case System.Net.HttpStatusCode.UnsupportedMediaType:
                    result = new UnsupportedMediaTypeResult(); break;
                default:
                    result = new BadRequestObjectResult(content); break;
            }
            return result;
        }
    }
}