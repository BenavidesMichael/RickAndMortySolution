using CommunityToolkit.Mvvm.Input;
using RickAndMorty.Models;
using RickAndMorty.Services;
using RickAndMorty.Views;
using System.Collections.ObjectModel;

namespace RickAndMorty.ViewModels;

public partial class CharacterViewModel : BaseViewModel
{
    IDialogService _dialogService;
    ICharacterService _characterService;
    public ObservableCollection<Character> Characters { get; } = new();

    public CharacterViewModel(ICharacterService characterService, IDialogService dialogService)
    {
        Title = "Rick And Morty Character";
        _dialogService = dialogService;
        _characterService = characterService;
        GetCharacters();
    }


    [RelayCommand]
    async Task DetailCharacter(int Id)
    {
        var character = await _characterService.GetCharacterById(Id);
        await Shell.Current.GoToAsync($"{nameof(DetailsCharacterPage)}",
                                        true,
                                        new Dictionary<string, object>()
                                        {
                                            {
                                                "Character", character
                                            }
                                        });

    }

    async void GetCharacters()
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
