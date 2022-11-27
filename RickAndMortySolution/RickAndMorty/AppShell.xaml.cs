using RickAndMorty.Views;

namespace RickAndMorty
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CharacterPage), typeof(CharacterPage));
            Routing.RegisterRoute(nameof(DetailsCharacterPage), typeof(DetailsCharacterPage));
        }
    }
}