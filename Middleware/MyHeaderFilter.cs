using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GoldenSealWebApi.Middleware;

public partial class ApiKeyMiddleware
{
    public class MyHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = ApiKeyHeaderName,
                In = ParameterLocation.Header,
                Required = true // set to false if this is optional
            });
        }
    }
}

