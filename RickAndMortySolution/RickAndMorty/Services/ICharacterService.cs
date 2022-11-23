using RickAndMorty.Models;

namespace RickAndMorty.Services;

public interface ICharacterService
{
    Task<ApiResponse> GetCharacters();
}
