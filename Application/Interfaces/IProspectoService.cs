using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProspectoService // <--- Revisa que no diga "IProspectosService" (con S)
    {
        Task Crear(ProspectoDto prospectoDto);
        Task<IEnumerable<ProspectoDto>> ObtenerPendientesPorVendedor(Guid vendedorId);
    }
}