using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProspectoRepository
    {
        // Guardar el lead que captura la recepcionista
        Task AddAsync(Prospecto prospecto);

        // Obtener los prospectos asignados a un vendedor específico
        Task<IEnumerable<Prospecto>> GetByVendedorIdAsync(Guid vendedorId);

        // Obtener todos los prospectos de una empresa (para la Gerente)
        Task<IEnumerable<Prospecto>> GetByEmpresaIdAsync(int empresaId);

        // Para cuando el vendedor atienda al cliente
        Task UpdateAsync(Prospecto prospecto);

        Task<Prospecto?> GetByIdAsync(Guid id);

        Task<IEnumerable<Prospecto>> GetAllAsync();
    }
}