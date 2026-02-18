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

        public async Task<IEnumerable<Prospecto>> GetAllAsync()
        {
            // Eager Loading: Traemos las tablas relacionadas para que AutoMapper tenga datos que procesar.
            return await _context.Prospectos
                .Include(p => p.Empresa)  // Carga la entidad Empresa
                .Include(p => p.Vendedor) // Carga la entidad Usuario/Vendedor
                .OrderByDescending(p => p.FechaRegistro)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prospecto>> GetByVendedorIdAsync(Guid vendedorId)
        {
            // Agregamos Include aquí también para que las listas filtradas también muestren nombres.
            return await _context.Prospectos
                .Include(p => p.Empresa)
                .Include(p => p.Vendedor)
                .Where(p => p.VendedorId == vendedorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prospecto>> GetByEmpresaIdAsync(int empresaId)
        {
            return await _context.Prospectos
                .Include(p => p.Empresa)
                .Include(p => p.Vendedor)
                .Where(p => p.EmpresaId == empresaId)
                .ToListAsync();
        }

        public async Task<Prospecto?> GetByIdAsync(Guid id)
        {
            // Usamos FirstOrDefaultAsync con Include en lugar de FindAsync (que no soporta Includes).
            return await _context.Prospectos
                .Include(p => p.Empresa)
                .Include(p => p.Vendedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Prospecto prospecto)
        {
            _context.Prospectos.Update(prospecto);
            await _context.SaveChangesAsync();
        }

        public async Task MarcarComoAtendido(Guid prospectoId)
        {
            var prospecto = await _context.Prospectos.FindAsync(prospectoId);

            if (prospecto != null)
            {
                prospecto.Atendido = true;
                _context.Entry(prospecto).Property(x => x.Atendido).IsModified = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}