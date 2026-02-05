using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductoRepository
    {
        //Obtener un producto por su ID
        Task<Producto?> GetByIdAsync(int  id);
        //Obtener todos los productos filtrados por las marcas que la empresa pueda vender

        Task<IEnumerable<Producto>> GetProductosPorEmpresaAsync(int empresaId);

        //Guardar un nuevo produto 
        Task AddAsync(Producto producto);

        // DESACOPLAMIENTO: La logica de ventas no dependará de SQL 
        // SEGURIDAD: GetProductoPorEmpresaAsync: Obligo al sistema a siempre hago un filtro por razon social 
    }
}
