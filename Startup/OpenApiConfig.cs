using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Runtime.CompilerServices;

namespace MHWilds_Armor_Web_API.Startup
{
    public static class OpenApiConfig
    {
        public static void AddOpenApiServices(this IServiceCollection services)
        {
            //Comment/uncomment accordingly when working on development vs when pushing to production
            
            //Development
            //services.AddOpenApi();

            //Production
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
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.Title = "Monster Hunter Armor API";
                options.HideClientButton = true;
            });
        }
    }
}
