using Microsoft.EntityFrameworkCore;
using PokeMudBlazor8.Client.Pages;
using PokeMudBlazor8.Components;
using MudBlazor.Services;
using PokeMudBlazor8.Client.Services;
using PokeMudBlazor8.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddMudServices();
// no entiendo pq si no registro el servicio de cliente luego tengo errores
builder.Services.AddScoped<PokemonApiService>();  // Registro del servicio desde cliente PokeApiService
builder.Services.AddSingleton<PokemonService>(); //importar servicio-> Services/PokemonService
builder.Services.AddControllers(); // importando Controllers/
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 35)) // Ajusta la versión según tu MySQL
    )
);

var app = builder.Build();
app.UseRouting(); 
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PokeMudBlazor8.Client._Imports).Assembly);

app.UseCors("AllowBlazorClient"); // Usa la política de CORS
app.MapControllers();

app.UseAuthorization();

app.Run();