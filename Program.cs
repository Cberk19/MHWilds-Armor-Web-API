using MHWilds_Armor_Web_API.Endpoints;
using MHWilds_Armor_Web_API.Startup;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    DotNetEnv.Env.Load();
}

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.AddRootEndpoints();

app.AddArmorEndpoints();

app.Run();