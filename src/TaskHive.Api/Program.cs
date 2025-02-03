var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/projects", () =>
{
    Project[] projects = { new("project1", "John", new DateTime(2025, 4, 1, 0, 0, 0), DateTime.Now) };

    return projects;
});
app.Run();


