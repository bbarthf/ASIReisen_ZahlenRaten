namespace zahlenRaten.Services;

public sealed record ApiGuessStatEvent(
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
