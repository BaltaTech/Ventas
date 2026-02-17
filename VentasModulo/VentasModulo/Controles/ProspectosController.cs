using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace VentasModulo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProspectosController : ControllerBase
    {
        private readonly IProspectoService _prospectoService;
        private readonly IEmpresaService _empresaService;
        private readonly IUsuarioService _usuarioService;

        public ProspectosController(
            IProspectoService prospectoService,
            IEmpresaService empresaService,
            IUsuarioService usuarioService)
        {
            _prospectoService = prospectoService;
            _empresaService = empresaService;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProspectoDto>>> Get()
        {
            var prospectos = await _prospectoService.ObtenerTodos();
            return Ok(prospectos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProspectoDto prospectoDto)
        {
            if (prospectoDto == null) return BadRequest();
            await _prospectoService.Crear(prospectoDto);
            return Ok();
        }

        // --- EL MÉTODO QUE TE FALTABA ---
        [HttpPut("{id}/atender")]
        public async Task<IActionResult> MarcarComoAtendido(Guid id)
        {
            try
            {
                // Llamamos al servicio del servidor, que a su vez llamará al repositorio
                await _prospectoService.MarcarComoAtendido(id);
                return NoContent(); // Respuesta 204: Éxito, sin contenido que devolver
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error al actualizar el prospecto: {ex.Message}" });
            }
        }

        [HttpGet("empresas")]
        public async Task<ActionResult<IEnumerable<EmpresaDto>>> GetEmpresas()
        {
            var empresas = await _empresaService.ObtenerEmpresasHabilitadas();
            return Ok(empresas);
        }

        [HttpGet("vendedores")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetVendedores()
        {
            var vendedores = await _usuarioService.ObtenerVendedoresActivos();
            return Ok(vendedores);
        }
    }
}