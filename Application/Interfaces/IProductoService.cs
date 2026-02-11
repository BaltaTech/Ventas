using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProductoService
    {
        // 1. Obtiene solo los productos que la empresa tiene permitido vender
        // (Aquí es donde se aplica el filtro de Trane vs Todas las marcas)
        Task<IEnumerable<ProductoDto>> ObtenerTodos(int empresaId);

        // 2. Buscamos por int porque así está en el Dominio
        Task<ProductoDto> ObtenerPorId(int id);

        // 3. Crear un producto nuevo desde el panel de administración
        Task Crear(ProductoDto productoDto);

        // --- MÉTODOS ADICIONALES RECOMENDADOS PARA TU FLUJO ---

        // 4. Útil para que el vendedor filtre rápidamente por capacidad (BTU/Tonelaje)
        Task<IEnumerable<ProductoDto>> ObtenerPorFiltroTecnico(int empresaId, string tipoEquipo);

        // 5. Para actualizar precios o descripciones
        Task Actualizar(ProductoDto productoDto);
    }
}
