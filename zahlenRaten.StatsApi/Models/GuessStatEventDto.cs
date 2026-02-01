namespace zahlenRaten.StatsApi.Models;

public sealed record GuessStatEventDto(
    DateTimeOffset TimestampUtc,
    string PlayerName,
    string Difficulty,
    int Min,
    int Max,
    int Guess,
    string Outcome,
    int Attempt,
    double? ElapsedSeconds
);
