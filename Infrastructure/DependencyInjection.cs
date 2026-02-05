using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Configuración de la base de datos 
        services.AddDbContext<VentasDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // 2. Registro de Repositorios (Inyección de Dependencias) 
        services.AddScoped<IProductoRepository, ProductoRepository>();

        return services;
    }
}