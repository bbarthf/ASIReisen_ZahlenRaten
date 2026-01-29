namespace zahlenRaten.Services;

public static class StatsPaths
{
    public static string GetDefaultJsonlPath()
    {
        var baseDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(baseDir, "zahlenRaten", "guesses.jsonl");
    }
}
