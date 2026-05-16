using MHWilds_Armor_Web_API.Endpoints;
using MHWilds_Armor_Web_API.Startup;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    DotNetEnv.Env.Load();
}

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.AddRootEndpoints();

app.AddArmorEndpoints();

if(builder.Environment.IsDevelopment())
    app.Run();
else
{
    app.Run($"http://0.0.0.0:{port}");
}