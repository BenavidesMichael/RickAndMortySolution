namespace RickAndMorty.Models;

public class Episode
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AirDate { get; set; }
    public string Code { get; set; }
    public IEnumerable<Character> Characters { get; set; }
    public string Url { get; set; }
    public DateTime Created { get; set; }
}
