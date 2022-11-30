using CommunityToolkit.Mvvm.Input;
using RickAndMorty.Models;
using RickAndMorty.Services;
using RickAndMorty.Views;
using System.Collections.ObjectModel;

namespace RickAndMorty.ViewModels;

public partial class CharacterViewModel : BaseViewModel
{
    string _nextCharactersUri;
    IDialogService _dialogService;
    ICharacterService _characterService;
    public ObservableCollection<Character> Characters { get; set; } = new();


    public CharacterViewModel(ICharacterService characterService, IDialogService dialogService)
    {
        Title = "Rick And Morty Character";
        _dialogService = dialogService;
        _characterService = characterService;
        GetCharacters();
    }


    async void GetCharacters()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var result = await _characterService.GetCharacters();
            _nextCharactersUri = result.Info.Next;

            foreach (var item in result.Results)
                Characters.Add(item);
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


    [RelayCommand]
    async void GetNextCharacters()
    {
        if (IsBusy)
            return;

        try
        {
            if (!string.IsNullOrEmpty(_nextCharactersUri))
            {
                IsBusy = true;
                var result = await _characterService.GetNextCharacters(_nextCharactersUri);
                _nextCharactersUri = result?.Info.Next;

                foreach (var item in result.Results)
                    Characters.Add(item);
            }
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


    [RelayCommand]
    async Task DetailCharacter(int Id)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var character = await _characterService.GetCharacterById(Id);
            await Shell.Current.GoToAsync($"{nameof(DetailsCharacterPage)}",
                                            true,
                                            new Dictionary<string, object>() { { "Character", character } });
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
