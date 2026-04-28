using Scalar.AspNetCore;

namespace MHWilds_Armor_Web_API.Startup
{
    public static class OpenApiConfig
    {
        public static void AddOpenApiServices(this IServiceCollection services)
        {
            services.AddOpenApi();
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
