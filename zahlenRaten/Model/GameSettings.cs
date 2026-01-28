namespace zahlenRaten.Model;

public sealed class GameSettings
{
    public DifficultyLevel Difficulty { get; init; } = DifficultyLevel.Easy;

    public int Min => 1;

    public int Max => Difficulty switch
    {
        DifficultyLevel.Easy => 10,
        DifficultyLevel.Medium => 50,
        DifficultyLevel.Hard => 100,
        _ => 10
    };
}
