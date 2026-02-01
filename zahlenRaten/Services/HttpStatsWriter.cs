using System.Net.Http.Json;
using System.Text.Json;
using zahlenRaten.Model;

namespace zahlenRaten.Services;

public sealed class HttpStatsWriter : IStatsWriter, IDisposable
{
    private readonly HttpClient _httpClient;

    public HttpStatsWriter(Uri baseAddress)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = baseAddress,
            Timeout = TimeSpan.FromSeconds(2)
        };
    }

    public async Task WriteGuessAsync(GuessStatEvent evt, CancellationToken cancellationToken = default)
    {
        var payload = new ApiGuessStatEvent(
            TimestampUtc: evt.TimestampUtc,
            PlayerName: evt.PlayerName,
            Difficulty: evt.Difficulty.ToString(),
            Min: evt.Min,
            Max: evt.Max,
            Guess: evt.Guess,
            Outcome: evt.Outcome.ToString(),
            Attempt: evt.Attempt,
            ElapsedSeconds: evt.ElapsedSeconds);

        using var response = await _httpClient.PostAsJsonAsync(
            "/api/guesses",
            payload,
            new JsonSerializerOptions { PropertyNamingPolicy = null },
            cancellationToken);

        response.EnsureSuccessStatusCode();
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
