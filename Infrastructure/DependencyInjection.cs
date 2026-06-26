using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Security; 


namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Configuración de la base de datos (SQL Server)
        services.AddDbContext<VentasDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // 2. Registro de Repositorios (Inyección de Dependencias) 
        services.AddScoped<IProductoRepository, ProductoRepository>();

        //  guardar datos
        services.AddScoped<IProspectoRepository, ProspectoRepository>();
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        // Registro de Seguridad
        services.AddSingleton<PasswordHasher>();
        services.AddScoped<JwtProvider>();

        // 2. Registro del servicio de aplicación
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}