using Microsoft.OpenApi;
using Scalar.AspNetCore;

namespace MHWilds_Armor_Web_API.Startup
{
    public static class OpenApiConfig
    {
        public static void AddOpenApiServices(this IServiceCollection services)
        {
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Servers = new List<OpenApiServer>
                    {
                        new OpenApiServer { Url = "https://api.mhwildsarmorapi.com" }
                    };
                    return Task.CompletedTask;
                });
            });
        }

        public static void UseOpenApi(this WebApplication app)
        {
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.Title = "Monster Hunter Armor API";
                    options.HideClientButton = true;
                });
            }
        }
    }
}
