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
            // El mapper usará la configuración de MappingProfile para asignar EmpresaId y VendedorId
            var prospecto = _mapper.Map<Prospecto>(prospectoDto);

            prospecto.Id = Guid.NewGuid(); // Aseguramos el ID si no viene del cliente
            prospecto.FechaRegistro = DateTime.Now;
            prospecto.Atendido = false;

            await _repository.AddAsync(prospecto);
        }

        public async Task<IEnumerable<ProspectoDto>> ObtenerTodos()
        {
            // IMPORTANTE: El repositorio DEBE incluir .Include(p => p.Vendedor) y .Include(p => p.Empresa)
            // en su método GetAllAsync para que el Mapper encuentre los nombres.
            var prospectosEntities = await _repository.GetAllAsync();

            // Aquí ocurre la magia: AutoMapper toma el 'Vendedor.Nombre' y lo pone en 'NombreVendedor'
            return _mapper.Map<IEnumerable<ProspectoDto>>(prospectosEntities);
        }

        public async Task MarcarComoAtendido(Guid prospectoId)
        {
            await _repository.MarcarComoAtendido(prospectoId);
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
    }
}