using Domain.Entities;

namespace Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task AddAsync(Usuario usuario); // Método necesario para guardar

    // --- NUEVO MÉTODO PARA LOGIN ---
    Task<Usuario?> GetByEmailAsync(string email);
}