using Application.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VentasModulo.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registramos nuestro servicio de API
builder.Services.AddScoped<IProspectoService, ProspectoApiClient>();

await builder.Build().RunAsync();
