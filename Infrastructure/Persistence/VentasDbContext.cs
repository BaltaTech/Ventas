using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class VentasDbContext : DbContext
    {
        public VentasDbContext(DbContextOptions<VentasDbContext> options) : base(options) { }

        // El tipo dentro de <> debe ser la Clase (Marca, Empresa, Producto)
        public DbSet<Marca> Marcas => Set<Marca>();
        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Producto> Productos => Set<Producto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aquí se configurarán las reglas de las tablas después
            // Defino Llaves primarias 
            // Configurar relaciones: Indicar que una empresa tiene muchas MarcasPermitidas
            // Validacion de base de datos 

        }
    }
}