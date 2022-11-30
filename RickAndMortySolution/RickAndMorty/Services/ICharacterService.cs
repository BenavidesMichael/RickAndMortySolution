using RickAndMorty.Models;

namespace RickAndMorty.Services;

public interface ICharacterService
{
    Task<ApiResponse> GetCharacters();
    Task<CharacterDetail> GetCharacterById(int Id);
    Task<ApiResponse> GetNextCharacters(string url);
}
