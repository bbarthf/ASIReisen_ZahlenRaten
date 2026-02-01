using zahlenRaten.Model;

namespace zahlenRaten.Services;

public sealed class CompositeStatsWriter : IStatsWriter
{
    private readonly IReadOnlyList<IStatsWriter> _writers;

    public CompositeStatsWriter(params IStatsWriter[] writers)
    {
        _writers = writers;
    }

    public async Task WriteGuessAsync(GuessStatEvent evt, CancellationToken cancellationToken = default)
    {
        foreach (var writer in _writers)
        {
            try
            {
                await writer.WriteGuessAsync(evt, cancellationToken);
            }
            catch
            {
                // Best-effort: writing stats must not break the game.
            }
        }
    }
}
