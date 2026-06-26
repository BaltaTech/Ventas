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
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        }, Assembly.GetExecutingAssembly());

        services.AddScoped<IProductoService, ProductoService>();
        services.AddScoped<IProspectoService, ProspectoService>(); 
        services.AddScoped<IEmpresaService, EmpresaService>();
        services.AddScoped<IUsuarioService, UsuarioService>();

        return services;
    }
}