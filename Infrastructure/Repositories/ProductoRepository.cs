using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly VentasDbContext _context;

        public ProductoRepository(VentasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos.Include(p => p.Marca).ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos.Include(p => p.Marca)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        // ESTE ES EL MÉTODO QUE FALTABA (Corrige el error CS0535)
        public async Task<IEnumerable<Producto>> GetProductosPorEmpresaAsync(int empresaId)
        {
            return await _context.Productos
                .Include(p => p.Marca)
                .Where(p => p.EmpresaId == empresaId)
                .ToListAsync();
        }
    }
}