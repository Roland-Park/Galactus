using System.Text.Json.Serialization;

namespace ReactionsServiceApi.Entities;

public class Mood
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
