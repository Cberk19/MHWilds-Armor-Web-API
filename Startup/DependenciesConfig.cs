using MHWilds_Armor_Web_API.Data;

namespace MHWilds_Armor_Web_API.Startup
{
    public static class DependenciesConfig
    {
        public static void AddDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddOpenApiServices();
            builder.Services.AddTransient<ArmorData>();
        }
    }
}
