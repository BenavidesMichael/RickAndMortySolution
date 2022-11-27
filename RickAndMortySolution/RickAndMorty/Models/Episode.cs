using System.Text.Json.Serialization;

namespace RickAndMorty.Models;

public class Episode
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonPropertyName("air_date")]
    public string AirDate { get; set; }

    [JsonPropertyName("episode")]
    public string Code { get; set; }
    public IEnumerable<string> Characters { get; set; }
    public string Url { get; set; }
    public DateTime Created { get; set; }
}
