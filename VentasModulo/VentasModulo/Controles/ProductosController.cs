using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;

namespace VentasModulo.Controllers;

[ApiController]
[Route("api/[controller]")] // Esto crea la ruta /api/productos
public class ProductosController : ControllerBase
{
    private readonly IProductoService _productoService;

    // Inyectamos el servicio de la capa de Aplicación
    public ProductosController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    // Ruta para obtener productos por ID de empresa
    [HttpGet("empresa/{empresaId}")]
    public async Task<ActionResult<IEnumerable<ProductoDto>>> GetByEmpresa(int empresaId)
    {
        var productos = await _productoService.ObtenerTodos(empresaId);
        return Ok(productos);
    }
}