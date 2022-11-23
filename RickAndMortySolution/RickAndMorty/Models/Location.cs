namespace RickAndMorty.Models;

public class Location
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Type { get; set; }
    public string Dimension { get; set; }
    public IEnumerable<string> Residents { get; set; }
    public DateTime Created { get; set; }
}
