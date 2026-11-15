public static class DataBase
{
    private static Dictionary<string, string> _data = new();

    public static string? GetValue(string key) => _data.GetValueOrDefault(key);

    public static void AddValue(string key, string value) => _data.TryAdd(key, value);
}
