namespace GoldenSealWebApi.Middleware;

public class ApiKeyValidator : IApiKeyValidator
{
    public const string ApiKeyName = "ApiKey";

    private readonly string _apiKey;
    public ApiKeyValidator(IConfiguration configuration)
    {
        _apiKey = configuration.GetValue<string>(ApiKeyName) ?? throw new Exception("Unable to parse the x-api-key");
    }
    public bool IsValidApiKey(string userApiKey)
    {
        if (string.IsNullOrWhiteSpace(userApiKey))
            return false;
        
        if (_apiKey != userApiKey)
            return false;

        return true;
    }
}