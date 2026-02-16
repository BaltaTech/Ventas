using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProspectoRepository : IProspectoRepository
    {
        private readonly VentasDbContext _context;

        public ProspectoRepository(VentasDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Prospecto prospecto)
        {
            await _context.Prospectos.AddAsync(prospecto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Prospecto>> GetByVendedorIdAsync(Guid vendedorId)
        {
            return await _context.Prospectos
                .Where(p => p.VendedorId == vendedorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prospecto>> GetByEmpresaIdAsync(int empresaId)
        {
            return await _context.Prospectos
                .Where(p => p.EmpresaId == empresaId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Prospecto prospecto)
        {
            _context.Prospectos.Update(prospecto);
            await _context.SaveChangesAsync();
        }

        public async Task<Prospecto?> GetByIdAsync(Guid id)
        {
            return await _context.Prospectos.FindAsync(id);
        }

        public async Task<IEnumerable<Prospecto>> GetAllAsync()
        {
            // Esto traerá todos los registros (incluyendo a Saul Baltazar)
            return await _context.Prospectos
                .Include(p => p.Empresa)  // Para traer la Razon Social
                .Include(p => p.Vendedor) // Para traer el nombre del vendedor
                .ToListAsync();
        }
    }
}