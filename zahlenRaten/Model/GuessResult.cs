namespace zahlenRaten.Model;

public sealed record GuessResult(
    GuessOutcome Outcome,
    string Message,
    int Guess,
    int Target,
    bool IsGameOver
);
