using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Net.Http;

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

        public async Task<IEnumerable<ProspectoDto>> ObtenerTodosPorEmpresa(int empresaId)
        {
            var prospectos = await _repository.GetByEmpresaIdAsync(empresaId);
            return _mapper.Map<IEnumerable<ProspectoDto>>(prospectos);
        }

        public async Task MarcarComoAtendido(Guid prospectoId)
        {
            var prospecto = await _repository.GetByIdAsync(prospectoId);
            if (prospecto != null)
            {
                prospecto.Atendido = true;
                await _repository.UpdateAsync(prospecto);
            }
        }
        public async Task<IEnumerable<ProspectoDto>> ObtenerTodos()
        {
            // 1. Pedimos todos los prospectos al repositorio (Base de datos)
            var prospectosEntities = await _repository.GetAllAsync(); // O el método que tengas en tu repositorio

            // 2. Usamos el mapper para convertir las entidades a DTOs
            return _mapper.Map<IEnumerable<ProspectoDto>>(prospectosEntities);
        }
    }
}