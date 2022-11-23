using Microsoft.Maui.Hosting;
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
        builder.Services.AddTransient<ICharacterService, CharacterService>();
        return builder;
    }
}
