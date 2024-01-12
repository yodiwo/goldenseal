using System.Net;

namespace GoldenSealWebApi.Middleware;

public partial class ApiKeyMiddleware
{
    public const string ApiKeyHeaderName = "x-api-Key";

    private readonly RequestDelegate _next;
    private readonly IApiKeyValidator _apiKeyValidation;
    public ApiKeyMiddleware(RequestDelegate next, IApiKeyValidator apiKeyValidation)
    {
        _next = next;
        _apiKeyValidation = apiKeyValidation;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        if (string.IsNullOrWhiteSpace(context.Request.Headers[ApiKeyHeaderName]))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }
        string? userApiKey = context.Request.Headers[ApiKeyHeaderName];
        if (!_apiKeyValidation.IsValidApiKey(userApiKey!))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }
        await _next(context);
    }
}

