using System.Text.Json;

static class ReadItems
{
    private static string _path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory,
        @"Data/Items.json"));

    public static List<Item> LoadAll()
    {
        string json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<List<Item>>(json);
    }
}
