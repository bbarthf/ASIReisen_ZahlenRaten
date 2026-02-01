using zahlenRaten.Model;

namespace zahlenRaten.Services
{
    public interface IStatsWriter
    {
        Task WriteGuessAsync(GuessStatEvent evt, CancellationToken cancellationToken = default);
    }
}
