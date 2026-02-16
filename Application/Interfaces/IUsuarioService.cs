using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        // Este método filtrará solo a los usuarios del Departamento.Ventas
        Task<IEnumerable<UsuarioDto>> ObtenerVendedoresActivos();
    }
}