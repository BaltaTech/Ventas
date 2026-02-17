using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProspectoService : IProspectoService
    {
        private readonly IProspectoRepository _repository;
        private readonly IMapper _mapper;

        public ProspectoService(IProspectoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Crear(ProspectoDto prospectoDto)
        {
            var prospecto = _mapper.Map<Prospecto>(prospectoDto);
            prospecto.FechaRegistro = DateTime.Now;
            prospecto.Atendido = false;

            await _repository.AddAsync(prospecto);
        }

        public async Task<IEnumerable<ProspectoDto>> ObtenerPendientesPorVendedor(Guid vendedorId)
        {
            var prospectos = await _repository.GetByVendedorIdAsync(vendedorId);
            var pendientes = prospectos.Where(p => !p.Atendido);
            return _mapper.Map<IEnumerable<ProspectoDto>>(pendientes);
        }

        public async Task<IEnumerable<ProspectoDto>> ObtenerTodosPorEmpresa(int empresaId)
        {
            var prospectos = await _repository.GetByEmpresaIdAsync(empresaId);
            return _mapper.Map<IEnumerable<ProspectoDto>>(prospectos);
        }

        // VERSION OPTIMIZADA: Delegamos la responsabilidad al Repositorio
        public async Task MarcarComoAtendido(Guid prospectoId)
        {
            // Ya no buscamos el objeto aquí, dejamos que el Repo lo haga en una sola transacción
            await _repository.MarcarComoAtendido(prospectoId);
        }

        public async Task<IEnumerable<ProspectoDto>> ObtenerTodos()
        {
            var prospectosEntities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProspectoDto>>(prospectosEntities);
        }
    }
}