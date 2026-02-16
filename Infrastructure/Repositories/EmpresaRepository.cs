using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore; // <--- ESTO ES VITAL

namespace Infrastructure.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly VentasDbContext _context;
    public EmpresaRepository(VentasDbContext context) => _context = context;

    // Ahora ToListAsync() ya no marcará error
    public async Task<IEnumerable<Empresa>> GetAllAsync() => await _context.Empresas.ToListAsync();
}