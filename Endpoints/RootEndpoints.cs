namespace MHWilds_Armor_Web_API.Endpoints
{
    public static class RootEndpoints
    {
        public static void AddRootEndpoints(this WebApplication app)
        {
            app.MapGet("/", () =>
            {
                return Results.Redirect("https://api.mhwildsarmorapi.com/scalar");  
            }
            );
        }
    }
}
