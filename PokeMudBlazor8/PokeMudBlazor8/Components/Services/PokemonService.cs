using RestSharp;
using SharedModels;

namespace PokeMudBlazor8.Components.Services;



public class PokemonService
{
    private readonly RestClient _client;

    public PokemonService()
    {
        _client = new RestClient("https://pokeapi.co/api/v2/");
    }

    public async Task<List<Pokemon>> GetPokemonsAsync(int count = 4)
    {
        var pokemons = new List<Pokemon>();
        
        for (int i = 1; i <= count; i++)
        {
            var request = new RestRequest($"pokemon/{i}", Method.Get);
            var response = await _client.ExecuteAsync<Pokemon>(request);
            
            if (response.IsSuccessful)
            {
                pokemons.Add(response.Data);
            }
        }

        return pokemons;
    }
}