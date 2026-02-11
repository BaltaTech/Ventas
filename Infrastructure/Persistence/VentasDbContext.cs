using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class VentasDbContext : DbContext
    {
        public VentasDbContext(DbContextOptions<VentasDbContext> options) : base(options) { }

        public DbSet<Marca> Marcas => Set<Marca>();
        public DbSet<Empresa> Empresas => Set<Empresa>();
        public DbSet<Producto> Productos => Set<Producto>();
        // Agregamos Prospectos para el registro de leads
        public DbSet<Prospecto> Prospectos => Set<Prospecto>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Configuración de Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.Id);
                // Aseguramos que el precio tenga precisión decimal para aire acondicionado
                entity.Property(p => p.PrecioBase).HasPrecision(18, 2);
            });

            // 2. Relación Empresa - Prospecto
            // Una Empresa puede tener muchos prospectos registrados
            modelBuilder.Entity<Prospecto>()
                .HasOne(p => p.Empresa)
                .WithMany()
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. Relación Vendedor (Usuario) - Prospecto
            // Un vendedor tiene asignados muchos prospectos
            modelBuilder.Entity<Prospecto>()
                .HasOne(p => p.Vendedor)
                .WithMany()
                .HasForeignKey(p => p.VendedorId)
                .OnDelete(DeleteBehavior.Restrict);

            // 4. Configuración de Marca
            modelBuilder.Entity<Marca>().HasKey(m => m.Id);
        }
    }
}