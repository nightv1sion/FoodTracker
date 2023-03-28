namespace src.ApiGateways.APIGateway.Services.Contracts;

public interface IStringContentCreator
{
    StringContent CreateContent(string body);
}