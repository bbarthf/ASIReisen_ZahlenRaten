var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton(sp =>
{
    var baseDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    var filePath = Path.Combine(baseDir, "zahlenRaten", "api-guesses.jsonl");
    return new zahlenRaten.StatsApi.Services.JsonlEventStore(filePath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/guesses", async (
    zahlenRaten.StatsApi.Models.GuessStatEventDto evt,
    zahlenRaten.StatsApi.Services.JsonlEventStore store,
    CancellationToken cancellationToken) =>
{
    Console.WriteLine($"[StatsApi] Received guess event: {System.Text.Json.JsonSerializer.Serialize(evt)}");
    await store.AppendAsync(evt, cancellationToken);
    return Results.Accepted();
});

app.MapGet("/api/guesses", async (
    int? count,
    zahlenRaten.StatsApi.Services.JsonlEventStore store,
    CancellationToken cancellationToken) =>
{
    var items = await store.ReadLastAsync(count ?? 50, cancellationToken);
    Console.WriteLine($"[StatsApi] Served {items.Count} guess event(s).");
    return Results.Ok(items);
});

app.Run();
