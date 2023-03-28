using System.Text;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Services;
public class StringContentCreator : IStringContentCreator
{
    public StringContent CreateContent(string body)
    {
        return new StringContent(body, Encoding.UTF8, "application/json");
    }
}