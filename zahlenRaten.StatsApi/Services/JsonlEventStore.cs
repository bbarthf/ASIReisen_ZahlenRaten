using System.Text;
using System.Text.Json;
using zahlenRaten.StatsApi.Models;

namespace zahlenRaten.StatsApi.Services;

public sealed class JsonlEventStore
{
    private readonly string _filePath;
    private readonly SemaphoreSlim _gate = new(1, 1);
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = null
    };

    public JsonlEventStore(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<IReadOnlyList<GuessStatEventDto>> ReadLastAsync(int count, CancellationToken cancellationToken)
    {
        if (count <= 0)
        {
            return Array.Empty<GuessStatEventDto>();
        }

        await _gate.WaitAsync(cancellationToken);
        try
        {
            if (!File.Exists(_filePath))
            {
                return Array.Empty<GuessStatEventDto>();
            }

            var lines = await File.ReadAllLinesAsync(_filePath, cancellationToken);
            var start = Math.Max(0, lines.Length - count);
            var result = new List<GuessStatEventDto>(Math.Min(count, lines.Length));

            for (var i = start; i < lines.Length; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                var evt = JsonSerializer.Deserialize<GuessStatEventDto>(line, _jsonOptions);
                if (evt is not null)
                {
                    result.Add(evt);
                }
            }

            return result;
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task AppendAsync(GuessStatEventDto evt, CancellationToken cancellationToken)
    {
        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var json = JsonSerializer.Serialize(evt, _jsonOptions);

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
