namespace zahlenRaten.Model;

public sealed record GuessStatEvent(
    DateTimeOffset TimestampUtc,
    string PlayerName,
    DifficultyLevel Difficulty,
    int Min,
    int Max,
    int Guess,
    GuessOutcome Outcome,
    int Attempt,
    double? ElapsedSeconds
);
