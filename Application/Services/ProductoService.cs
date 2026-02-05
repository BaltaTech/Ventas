using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces; //Para usar el repositorio
using AutoMapper;
using Domain.Entities; // Para las convenciones automaticas 

namespace Application.Services
{
   public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        //Se inyecta el repositorio y el Mapper 
        
        public ProductoService(IProductoRepository repository, IMapper mapper)
        {
          _repository = repository;
            _mapper = mapper;   
        
        }

        public async Task<IEnumerable<ProductoDto>> ObtenerTodos(int empresaId)
        {
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

    }
}
