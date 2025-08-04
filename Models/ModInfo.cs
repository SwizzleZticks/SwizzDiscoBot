using System.Text.Json.Serialization;

namespace SwizzBotDisco.Models;

public class ModInfo
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("summary")]
    public string Summary { get; set; }
    [JsonPropertyName("picture_url")]
    public string PictureUrl { get; set; }
    [JsonPropertyName("mod_id")]
    public int ModId { get; set; }
    [JsonPropertyName("created_timestamp")]
    public long CreatedTimestamp { get; set; }
}