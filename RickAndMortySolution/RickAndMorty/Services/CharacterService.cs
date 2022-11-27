using RickAndMorty.Models;
using System.Net.Http.Json;

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

    public async Task<Character> GetCharacterById(int Id)
    {
        string url = $"{_BaseUrl}/character/{Id}";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Character>();
        }

        return default;
    }
}
