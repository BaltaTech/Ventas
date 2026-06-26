using Application.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VentasModulo.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage; 

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// 1. Configuracion del HttpClient
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// 2. Registro de Servicios de API (Client Side)
builder.Services.AddScoped<IProspectoService, ProspectoApiClient>();
builder.Services.AddScoped<IEmpresaService, EmpresaApiClient>();
builder.Services.AddScoped<IUsuarioService, UsuarioApiClient>();
builder.Services.AddScoped<AuthApiClient>();

// 3. Configuracion de Almacenamiento Local
builder.Services.AddBlazoredLocalStorage(); // 2. Registramos el LocalStorage

// 4. Soporte para Autorizacion y Estado de Autenticacion Real
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

// 3. REGISTRO DEL PROVIDER REAL
builder.Services.AddScoped<CustomAuthStateProvider>();

// Registramos AuthenticationStateProvider para que Blazor lo use internamente
builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());

await builder.Build().RunAsync();

