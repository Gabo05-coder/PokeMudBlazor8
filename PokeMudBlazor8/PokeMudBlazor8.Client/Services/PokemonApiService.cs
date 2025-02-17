using RestSharp;
using SharedModels;

namespace PokeMudBlazor8.Client.Services
{
    public class PokemonApiService
    {
        private readonly RestClient _client;

        // Ajusta la URL base al dominio donde esté tu backend
        public PokemonApiService()
        {
            _client = new RestClient("https://localhost:7195/api/");
        }

        public async Task<List<Pokemon>> GetPokemonsAsync(int count = 16)
        {
            var request = new RestRequest($"pokemon/pokemons?count={count}", Method.Get);
            var response = await _client.ExecuteAsync<List<Pokemon>>(request);

            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            // Si falla la solicitud, devuelve una lista vacía o maneja el error
            return new List<Pokemon>();
        }
    }
}