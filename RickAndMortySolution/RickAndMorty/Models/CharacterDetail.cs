namespace RickAndMorty.Models
{
    public class CharacterDetail
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public IEnumerable<Episode> Episodes { get; set; }
    }
}
