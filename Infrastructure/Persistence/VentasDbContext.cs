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
        public DbSet<Prospecto> Prospectos => Set<Prospecto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Configuración de Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.PrecioBase).HasPrecision(18, 2);
            });

            // 2. Relación Empresa - Prospecto
            modelBuilder.Entity<Prospecto>()
                .HasOne(p => p.Empresa)
                .WithMany()
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            // 3. Relación Vendedor (Usuario) - Prospecto
            modelBuilder.Entity<Prospecto>()
                .HasOne(p => p.Vendedor)
                .WithMany()
                .HasForeignKey(p => p.VendedorId)
                .OnDelete(DeleteBehavior.Restrict);

            // 4. Configuración de Marca
            modelBuilder.Entity<Marca>().HasKey(m => m.Id);

            // 5. DATOS INICIALES (Seed Data)
            // Aquí agregamos tus dos empresas reales para evitar errores de llave foránea
            modelBuilder.Entity<Empresa>().HasData(
     new Empresa
     {
         Id = 1,
         RazonSocial = "AYC S.A. DE C.V.",
         VendeTodasLasMarcas = false // Esta solo venderá las que le asignemos luego
     },
     new Empresa
     {
         Id = 2,
         RazonSocial = "GRUPO AYC S.A. DE C.V.",
         VendeTodasLasMarcas = true // Esta puede vender todo el catálogo general
     }
 );
        }
    }
}