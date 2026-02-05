using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly VentasDbContext _context;

    // Inyectamos el DbContext que ya configuraste
    public ProductoRepository(VentasDbContext context)
    {
        _context = context;
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _context.Productos
            .Include(p => p.Marca) // Traemos la marca de una vez 
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Producto>> GetProductosPorEmpresaAsync(int empresaId)
    {
        // Por ahora regresamos todos, luego filtraremos por las reglas de la empresa 
        return await _context.Productos.Include(p => p.Marca).ToListAsync();
    }

    public async Task AddAsync(Producto producto)
    {
        await _context.Productos.AddAsync(producto);
        await _context.SaveChangesAsync(); // Guardamos físicamente en SQL 
    }
}