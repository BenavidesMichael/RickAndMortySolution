using Microsoft.Maui.Animations;
using RickAndMorty.Models;
using System.Linq;
using System.Net.Http.Json;
using static System.Net.Mime.MediaTypeNames;

namespace RickAndMorty.Services;

public class CharacterService : ICharacterService
{
    string _BaseUrl = "https://rickandmortyapi.com/api";
    HttpClient _httpClient;

    public CharacterService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<ApiResponse> GetCharacters()
    {
        string url = $"{_BaseUrl}/character";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<ApiResponse>();
        }

        return default;
    }

    public async Task<CharacterDetail> GetCharacterById(int Id)
    {
        Character character = new();
        string episodeNumber = string.Empty;
        bool nbreEp = false;

        using (var httpClient = new HttpClient())
        {
            string urlCharacter = $"{_BaseUrl}/character/{Id}";
            var response = await _httpClient.GetAsync(urlCharacter);

            if (response.IsSuccessStatusCode)
                character = await response.Content.ReadFromJsonAsync<Character>();

            nbreEp= character?.Episode.Count > 1;
            episodeNumber = string.Join(",", character?.Episode.Select(ep => ep.Split("/").Last()));
        }

        IEnumerable<Episode> episodes = Enumerable.Empty<Episode>();
        using (var httpClient = new HttpClient())
        {
            if (episodeNumber is not null)
            {
                string urlEpisode = $"{_BaseUrl}/episode/{episodeNumber}";
                var episodesResponse = await _httpClient.GetAsync(urlEpisode);

                if (episodesResponse.IsSuccessStatusCode)
                {
                    episodes = nbreEp ? await episodesResponse.Content.ReadFromJsonAsync<IEnumerable<Episode>>()
                                      : episodes = episodes.Append(await episodesResponse.Content.ReadFromJsonAsync<Episode>());
                }
            }
        }

        var characterDetails = new CharacterDetail()
        {
            Name = character.Name,
            Image = character.Image,
            Episodes = episodes
        };

        return characterDetails;
    }
}
