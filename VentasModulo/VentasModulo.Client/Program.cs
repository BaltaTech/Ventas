using Application.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VentasModulo.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 1. Configuración del HttpClient para comunicarse con la API (Server)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// 2. Registro de Servicios de API (Client Side)
// Aquí registramos las implementaciones "ApiClient", que son las que 
// realmente hacen las peticiones HTTP hacia tu controlador en el servidor.

builder.Services.AddScoped<IProspectoService, ProspectoApiClient>();
builder.Services.AddScoped<IEmpresaService, EmpresaApiClient>();
builder.Services.AddScoped<IUsuarioService, UsuarioApiClient>();

// 3. Iniciar la aplicación
await builder.Build().RunAsync();