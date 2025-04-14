using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using PokeMudBlazor8.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registra el servicio de Pokémon
builder.Services.AddScoped<PokemonApiService>();  // Registro del servicio
// Agrega MudBlazor
builder.Services.AddMudServices();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



await builder.Build().RunAsync();