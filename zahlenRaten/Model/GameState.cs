namespace zahlenRaten.Model;

public sealed class GameState
{
    public int TargetNumber { get; set; }
    public bool GameOver { get; set; }

    public string PlayerName { get; set; } = string.Empty;

    public int Attempts { get; set; }

    public DateTimeOffset? GameStartedAt { get; set; }
    public DateTimeOffset? GameEndedAt { get; set; }

    public TimeSpan? Elapsed =>
        GameStartedAt is null ? null : (GameEndedAt ?? DateTimeOffset.Now) - GameStartedAt.Value;
}
