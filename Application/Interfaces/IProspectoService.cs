using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProspectoService // <--- Revisa que no diga "IProspectosService" (con S)
    {
        Task Crear(ProspectoDto prospectoDto);
        Task<IEnumerable<ProspectoDto>> ObtenerPendientesPorVendedor(Guid vendedorId);
        Task<IEnumerable<ProspectoDto>> ObtenerTodosPorEmpresa(int empresaId);
        Task MarcarComoAtendido(Guid prospectoId);
        Task<IEnumerable<ProspectoDto>> ObtenerTodos(); // <-- AGREGA ESTA LÍNEA
    }
}