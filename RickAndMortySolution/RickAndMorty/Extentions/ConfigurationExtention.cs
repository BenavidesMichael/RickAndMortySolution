using RickAndMorty.Services;
using RickAndMorty.ViewModels;
using RickAndMorty.Views;

namespace RickAndMorty.Extentions;

public static class ConfigurationExtention
{
    public static MauiAppBuilder AddConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<CharacterViewModel>();
        builder.Services.AddSingleton<CharacterPage>();

        // services
        builder.Services.AddTransient<ICharacterService, CharacterService>();
        builder.Services.AddTransient<IDialogService, DialogService>();

        return builder;
    }
}
