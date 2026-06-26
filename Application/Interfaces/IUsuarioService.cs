using Application.DTOs;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> ObtenerVendedoresActivos();
        Task CrearVendedor(UsuarioDto usuarioDto);
    }
}