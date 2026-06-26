using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductoService
    {
        
        Task<IEnumerable<ProductoDto>> ObtenerTodos(int empresaId);
        Task<ProductoDto> ObtenerPorId(int id);
        Task Crear(ProductoDto productoDto);
        Task<IEnumerable<ProductoDto>> ObtenerPorFiltroTecnico(int empresaId, string tipoEquipo);
        Task Actualizar(ProductoDto productoDto);
    }
}
