using System.Text;
using System.Text.Json;
using zahlenRaten.Model;

namespace zahlenRaten.Services;

public interface IStatsWriter
{
    Task WriteGuessAsync(GuessStatEvent evt, CancellationToken cancellationToken = default);
}

public sealed class JsonlStatsWriter : IStatsWriter
{
    private readonly string _filePath;
    private readonly SemaphoreSlim _gate = new(1, 1);

    public JsonlStatsWriter(string filePath)
    {
        _filePath = filePath;
    }

    public async Task WriteGuessAsync(GuessStatEvent evt, CancellationToken cancellationToken = default)
    {
        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var json = JsonSerializer.Serialize(evt);

        await _gate.WaitAsync(cancellationToken);
        try
        {
            await File.AppendAllTextAsync(_filePath, json + Environment.NewLine, Encoding.UTF8, cancellationToken);
        }
        finally
        {
            _gate.Release();
        }
    }
}
