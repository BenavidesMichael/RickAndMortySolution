﻿using CommunityToolkit.Mvvm.ComponentModel;
using RickAndMorty.Models;

namespace RickAndMorty.ViewModels
{
    [QueryProperty(nameof(Character), nameof(Character))]
    public partial class DetailCharacterViewModel : BaseViewModel
    {
        [ObservableProperty]
        CharacterDetail character;

        public DetailCharacterViewModel()
        {
            this.Title = "Details Character";
        }
    }
}
