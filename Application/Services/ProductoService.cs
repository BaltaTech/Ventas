using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoDto>> ObtenerTodos(int empresaId)
        {
            // Filtra automáticamente por las reglas de Empresa A o B
            var productos = await _repository.GetProductosPorEmpresaAsync(empresaId);
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        public async Task<ProductoDto> ObtenerPorId(int id)
        {
            var producto = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductoDto>(producto);
        }

        public async Task Crear(ProductoDto productoDto)
        {
            var entidad = _mapper.Map<Domain.Entities.Producto>(productoDto);
            await _repository.AddAsync(entidad);
        }

        public async Task Actualizar(ProductoDto productoDto)
        {
            var entidad = _mapper.Map<Domain.Entities.Producto>(productoDto);
            await _repository.UpdateAsync(entidad);
        }

        // SOLUCIÓN AL ERROR CS0535: Implementación del filtro para el vendedor
        public async Task<IEnumerable<ProductoDto>> ObtenerPorFiltroTecnico(int empresaId, string tipoEquipo)
        {
            var productos = await _repository.GetProductosPorEmpresaAsync(empresaId);

            // Filtramos por el tipo de equipo (MiniSplit, Central, etc.)
            var filtrados = productos.Where(p =>
                p.Tipo.ToString().Equals(tipoEquipo, StringComparison.OrdinalIgnoreCase));

            return _mapper.Map<IEnumerable<ProductoDto>>(filtrados);
        }
    }
}