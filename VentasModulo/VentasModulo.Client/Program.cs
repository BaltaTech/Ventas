using Application.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VentasModulo.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage; // 1. Agregamos el using de la librería

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

// 3. Configuración de Almacenamiento Local
builder.Services.AddBlazoredLocalStorage(); // 2. Registramos el LocalStorage

// 4. Soporte para Autorización y Estado de Autenticación Real
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

// 3. REGISTRO DEL PROVIDER REAL
// Registramos la clase concreta para poder usar sus métodos (como NotifyUserAuthentication)
builder.Services.AddScoped<CustomAuthStateProvider>();

// Registramos AuthenticationStateProvider para que Blazor lo use internamente
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());

await builder.Build().RunAsync();

// ELIMINAMOS la clase PlaceholderAuthStateProvider de aquí abajo, ya no la necesitamos.