using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces; 

namespace Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repo;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpresaDto>> ObtenerEmpresasHabilitadas()
        {
            var empresas = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<EmpresaDto>>(empresas);
        }
    }
}
