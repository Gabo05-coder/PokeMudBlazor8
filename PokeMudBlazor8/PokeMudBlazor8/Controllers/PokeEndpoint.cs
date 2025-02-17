using Microsoft.AspNetCore.Mvc;
using PokeMudBlazor8.Services;

namespace PokeMudBlazor8.Controllers
{
    [Route("api/[controller]")] // se define la ruta que sera api/pokemon/
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // Endpoint para obtener una lista de pokemons
        [HttpGet("pokemons")] // la ruta del endpoint es api/pokemon/pokemons/
        public async Task<IActionResult> GetPokemons(int count = 16)
        {
            try
            {
                var pokemons = await _pokemonService.GetPokemonsAsync(count);
                return Ok(pokemons);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}