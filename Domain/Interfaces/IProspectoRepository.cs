using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProspectoRepository
    {
        Task AddAsync(Prospecto prospecto);
        Task<IEnumerable<Prospecto>> GetByVendedorIdAsync(Guid vendedorId);
        Task<IEnumerable<Prospecto>> GetByEmpresaIdAsync(int empresaId);
        Task UpdateAsync(Prospecto prospecto);
        Task<Prospecto?> GetByIdAsync(Guid id);
        Task<IEnumerable<Prospecto>> GetAllAsync();
        Task MarcarComoAtendido(Guid prospectoId);
    }
}