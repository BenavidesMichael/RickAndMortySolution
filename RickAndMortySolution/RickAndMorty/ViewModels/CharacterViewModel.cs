using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RickAndMorty.Models;
using RickAndMorty.Services;
using System.Collections.ObjectModel;

namespace RickAndMorty.ViewModels;

public partial class CharacterViewModel : BaseViewModel
{
    ICharacterService _characterService;
    IDialogService _dialogService;
    public ObservableCollection<Character> Characters { get; } = new();

    public Character characterSelected { get; set; }

    public CharacterViewModel(ICharacterService characterService, IDialogService dialogService)
    {
        Title = "Rick And Morty Character";
        _dialogService = dialogService; 
        _characterService = characterService;
        GetCharacters().ConfigureAwait(false);
    }


    [RelayCommand]
    async Task DetailCharacter()
    {
        await _dialogService.ShowAlertAsync(characterSelected.Name, "Name Character", "OK");
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
