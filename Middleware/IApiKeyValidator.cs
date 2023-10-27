namespace GoldenSealWebApi.Middleware;

public interface IApiKeyValidator
{
    bool IsValidApiKey(string userApiKey);
}
