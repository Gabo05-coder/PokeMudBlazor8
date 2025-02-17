using System.Text.Json;
using RestSharp;
using SharedModels;

namespace PokeMudBlazor8.Services
{
    public class PokemonService
    {
        private readonly RestClient _client;
        private const int MaxPokemonId = 1010; // Número máximo de Pokémon en la PokéAPI

        public PokemonService()
        {
            _client = new RestClient("https://pokeapi.co/api/v2/");
        }

        public async Task<List<Pokemon>> GetPokemonsAsync(int count)
        {
            var random = new Random();
            var pokemonList = new List<Pokemon>();

            for (int i = 0; i < count; i++)
            {
                int randomId = random.Next(1, MaxPokemonId + 1); // Genera un ID aleatorio

                var request = new RestRequest($"pokemon/{randomId}", Method.Get);
                var response = await _client.ExecuteAsync(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    // Deserializar manualmente el contenido JSON a tu modelo `Pokemon`
                    var pokemon = JsonSerializer.Deserialize<Pokemon>(response.Content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // Ignora mayúsculas/minúsculas en los nombres de propiedad
                    });

                    if (pokemon != null)
                    {
                        pokemonList.Add(pokemon);
                    }
                }
            }

            return pokemonList;
        }
    }
}
