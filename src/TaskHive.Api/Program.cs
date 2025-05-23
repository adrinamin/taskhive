using Microsoft.OpenApi.Models;
using TaskHive.Api;
using TaskHive.Api.Projects;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
// needs to be adjusted for prod environments
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// configuring swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskHive API", Description = "TaskHive API Docs", Version = "v1" });
});

builder.Services.RegisterServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseRouting();
    app.UseCors(); // Enable CORS
    app.MapOpenApi();
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "TaskHive API V1");
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.MapProjectApiRoutes();

app.Run();


