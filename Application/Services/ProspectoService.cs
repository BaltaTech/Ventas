using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;
using AutoMapper;
using Domain.Entities;

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
            // Aquí ocurre la magia: convertimos el DTO a la Entidad
            var prospecto = _mapper.Map<Prospecto>(prospectoDto);

            // Asignamos la fecha actual automáticamente
            prospecto.FechaRegistro = DateTime.Now;
            prospecto.Atendido = false;

            await _repository.AddAsync(prospecto);
        }

        public async Task<IEnumerable<ProspectoDto>> ObtenerPendientesPorVendedor(Guid vendedorId)
        {
            var prospectos = await _repository.GetByVendedorIdAsync(vendedorId);
            // Solo devolvemos los que no han sido atendidos
            var pendientes = prospectos.Where(p => !p.Atendido);

            return _mapper.Map<IEnumerable<ProspectoDto>>(pendientes);
        }
    }
}