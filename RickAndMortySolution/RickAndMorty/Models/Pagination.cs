namespace RickAndMorty.Models;

public class Pagination
{
    public int Count { get; set; }
    public int Pages { get; set; }
    public string Next { get; set; }
    public object Prev { get; set; }
}
