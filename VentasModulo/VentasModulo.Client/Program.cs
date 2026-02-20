using Application.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VentasModulo.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 1. Configuración del HttpClient
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// 2. Registro de Servicios de API (Client Side)
builder.Services.AddScoped<IProspectoService, ProspectoApiClient>();
builder.Services.AddScoped<IEmpresaService, EmpresaApiClient>();
builder.Services.AddScoped<IUsuarioService, UsuarioApiClient>();
builder.Services.AddScoped<AuthApiClient>();

// 3. Soporte para Autorización y Estado de Autenticación
// AddAuthorizationCore: Habilita los servicios de [Authorize] y Roles
builder.Services.AddAuthorizationCore();

// AddCascadingAuthenticationState: Es VITAL en .NET 8. 
// Registra el proveedor de estado que el componente <CascadingAuthenticationState> 
// en tu Routes.razor está buscando desesperadamente.
builder.Services.AddCascadingAuthenticationState();

// NOTA: Por ahora registraremos el proveedor predeterminado. 
// Tan pronto como el Login cargue, crearemos uno personalizado para leer el JWT.
builder.Services.AddScoped<AuthenticationStateProvider, PlaceholderAuthStateProvider>();

await builder.Build().RunAsync();

// --- Clase Temporal para evitar el error de inyección ---
// Puedes poner esto al final del archivo o en un archivo aparte
public class PlaceholderAuthStateProvider : AuthenticationStateProvider
{
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Por defecto, devolvemos un usuario anónimo (no logueado)
        var anonymous = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity());
        return Task.FromResult(new AuthenticationState(anonymous));
    }
}