using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductosPorEmpresaAsync(int empresaId);
        Task<Producto?> GetByIdAsync(int id);
        Task AddAsync(Producto producto);

        // AGREGA ESTA LÍNEA PARA QUITAR EL ERROR:
        Task UpdateAsync(Producto producto);
    }
}