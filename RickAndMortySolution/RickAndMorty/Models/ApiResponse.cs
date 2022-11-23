namespace RickAndMorty.Models;

public class ApiResponse
{
    public Pagination Info { get; set; }
    public IEnumerable<Character> Results { get; set; }
}
