using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence; 
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly VentasDbContext _context;

        public UsuarioRepository(VentasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // IMPLEMENTA ESTE MÉTODO PARA QUITAR EL ERROR
        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync(); // Importante para persistir en SQL
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            // Buscamos al usuario e incluimos la empresa para tener el EmpresaId listo
            return await _context.Usuarios
                .Include(u => u.Empresa)
                .FirstOrDefaultAsync(u => u.CorreoElectronico == email);
        }
    }
}