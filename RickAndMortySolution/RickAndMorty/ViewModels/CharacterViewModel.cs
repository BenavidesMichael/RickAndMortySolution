using RickAndMorty.Models;
using RickAndMorty.Services;
using System.Collections.ObjectModel;

namespace RickAndMorty.ViewModels;

public partial class CharacterViewModel : BaseViewModel
{
    ICharacterService _characterService;
    public ObservableCollection<Character> Characters { get; } = new();

    public CharacterViewModel(ICharacterService characterService)
    {
        Title = "Rick And Morty Character";
        _characterService = characterService;
        GetCharacters().ConfigureAwait(false);
    }

    async Task GetCharacters()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var result = await _characterService.GetCharacters();

            foreach (var item in result.Results)
                Characters.Add(item);

            IsBusy = false;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", $"Unable to get characters : {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }

    }
}
