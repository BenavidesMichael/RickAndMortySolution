using RickAndMorty.Models;
using System.Net.Http.Json;

namespace RickAndMorty.Services;

public class CharacterService : ICharacterService
{
    string _characterUrl = $"https://rickandmortyapi.com/api/character";
    string _episodeUrl = $"https://rickandmortyapi.com/api/episode";


    public async Task<ApiResponse> GetCharacters()
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(_characterUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse>();
            }
        }
        return null;
    }


    public async Task<ApiResponse> GetNextCharacters(string url)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponse>();
            }
        }

        return null;
    }


    public async Task<CharacterDetail> GetCharacterById(int Id)
    {
        Character character = new();
        string episodeNumber = string.Empty;
        bool nbreEp = false;

        using (var httpClient = new HttpClient())
        {
            string urlCharacter = $"{_characterUrl}/{Id}";
            var response = await httpClient.GetAsync(urlCharacter);

            if (response.IsSuccessStatusCode)
                character = await response.Content.ReadFromJsonAsync<Character>();

            nbreEp = character?.Episode.Count > 1;
            episodeNumber = string.Join(",", character?.Episode.Select(ep => ep.Split("/").Last()));
        }

        IEnumerable<Episode> episodes = Enumerable.Empty<Episode>();
        using (var httpClient = new HttpClient())
        {
            if (episodeNumber is not null)
            {
                string urlEpisode = $"{_episodeUrl}/{episodeNumber}";
                var episodesResponse = await httpClient.GetAsync(urlEpisode);

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
