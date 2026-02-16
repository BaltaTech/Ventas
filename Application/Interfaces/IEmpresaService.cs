using Application.DTOs;

namespace Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaDto>> ObtenerEmpresasHabilitadas();
    }
}