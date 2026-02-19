using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Mappings;
using Application.Interfaces; 
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
            cfg.AddProfile<MappingProfile>();
        }, Assembly.GetExecutingAssembly());

        services.AddScoped<IProductoService, ProductoService>();
        services.AddScoped<IProspectoService, ProspectoService>(); // <--- Esto ya no debería marcar error
        services.AddScoped<IEmpresaService, EmpresaService>();
        services.AddScoped<IUsuarioService, UsuarioService>();

        return services;
    }
}