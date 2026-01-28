using zahlenRaten.Model;

namespace zahlenRaten.Controller;

public sealed class GameController
{
    private readonly Random _random;
    private GameSettings _settings;
    private readonly GameState _state;

    public GameController(GameSettings settings, Random? random = null)
    {
        _settings = settings;
        _random = random ?? Random.Shared;
        _state = new GameState();
        StartNewGame();
    }

    public GameSettings Settings => _settings;
    public GameState State => _state;

    public void SetPlayerName(string? playerName)
    {
        _state.PlayerName = (playerName ?? string.Empty).Trim();
    }

    public void SetDifficulty(DifficultyLevel difficulty)
    {
        _settings = new GameSettings { Difficulty = difficulty };
    }

    public void StartNewGame()
    {
        _state.TargetNumber = _random.Next(_settings.Min, _settings.Max + 1);
        _state.GameOver = false;
        _state.Attempts = 0;
        _state.GameStartedAt = DateTimeOffset.Now;
        _state.GameEndedAt = null;
    }

    public GuessResult MakeGuess(string input)
    {
        GuessResult Result(GuessOutcome outcome, string message, int guess, bool isGameOver) =>
            new(outcome, message, guess, _state.TargetNumber, isGameOver);

        const string InvalidNumberMessage = "Please enter a valid number.";

        if (_state.GameOver)
        {
            return Result(GuessOutcome.Correct, "Game is over. Start a new game.", 0, true);
        }

        if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out var guess))
        {
            return Result(GuessOutcome.TooLow, InvalidNumberMessage, 0, false);
        }

        if (guess < _settings.Min || guess > _settings.Max)
        {
            return Result(GuessOutcome.TooLow, $"Please enter a number between {_settings.Min} and {_settings.Max}.", guess, false);
        }

        _state.Attempts++;

        var comparison = guess.CompareTo(_state.TargetNumber);
        GuessOutcome outcome;
        switch (comparison)
        {
            case < 0:
                outcome = GuessOutcome.TooLow;
                break;
            case > 0:
                outcome = GuessOutcome.TooHigh;
                break;
            default:
                outcome = GuessOutcome.Correct;
                break;
        }

        if (outcome == GuessOutcome.Correct)
        {
            _state.GameOver = true;
            _state.GameEndedAt = DateTimeOffset.Now;
            return Result(outcome, "Correct!", guess, true);
        }

        var message = outcome == GuessOutcome.TooLow ? "Too low." : "Too high.";
        return Result(outcome, message, guess, false);
    }
}
