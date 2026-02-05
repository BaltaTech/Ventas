using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductoService
    {
        // Agregamos el parámetro aquí para que coincida con el ProductoService
        Task<IEnumerable<ProductoDto>> ObtenerTodos(int empresaId);

        Task<ProductoDto> ObtenerPorId(int id);

        // Corregimos el nombre a productoDto (estaba como productoDtp)
        Task Crear(ProductoDto productoDto);

        // Definimos que puede hacer el usuario 
    }
}
