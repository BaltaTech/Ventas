using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore; 

namespace Infrastructure.Repositories;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly VentasDbContext _context;
    public EmpresaRepository(VentasDbContext context) => _context = context;
    public async Task<IEnumerable<Empresa>> GetAllAsync() => await _context.Empresas.ToListAsync();
}