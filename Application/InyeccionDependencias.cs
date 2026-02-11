using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Mappings;
using Application.Interfaces; // IMPORTANTE: Agrega esto
using Application.Services;
namespace Application;

public static class InyeccionDependencias
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Esta es la forma manual de registrar AutoMapper en las versiones nuevas
        // sin depender del paquete de "DependencyInjection" que causaba conflictos.
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<MappingProfile>(); // Reemplaza 'MappingProfile' por el nombre de tu clase de perfiles
        }, Assembly.GetExecutingAssembly());

        services.AddScoped<IProductoService, ProductoService>();
        services.AddScoped<IProspectoService, ProspectoService>(); // <--- Esto ya no debería marcar error

        return services;
    }
}