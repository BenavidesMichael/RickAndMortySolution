using RickAndMorty.Services;
using RickAndMorty.ViewModels;
using RickAndMorty.Views;

namespace RickAndMorty.Extentions;

public static class ConfigurationExtention
{
    public static MauiAppBuilder AddConfiguration(this MauiAppBuilder builder)
    {
        // services
        builder.Services.AddTransient<ICharacterService, CharacterService>();
        builder.Services.AddTransient<IDialogService, DialogService>();

        // ViewModels
        builder.Services.AddSingleton<CharacterViewModel>();
        // creation a chaque fois de la page avec un new character
        builder.Services.AddTransient<DetailCharacterViewModel>();

        // Views
        builder.Services.AddSingleton<CharacterPage>();
        builder.Services.AddTransient<DetailsCharacterPage>();

        return builder;
    }
}
