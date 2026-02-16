using Domain.Entities;

namespace Domain.Interfaces;

public interface IEmpresaRepository
{
    Task<IEnumerable<Empresa>> GetAllAsync();
}