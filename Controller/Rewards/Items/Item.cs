using System.Text.Json.Serialization;

class Item
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
