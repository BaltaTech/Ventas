using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Enums;

namespace Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerVendedoresActivos()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            // Filtramos por Ventas
            var vendedores = usuarios.Where(u => u.Departamento == Departamento.Ventas);

            return _mapper.Map<IEnumerable<UsuarioDto>>(vendedores);
        }

        // AGREGA ESTE MÉTODO PARA QUITAR EL ERROR DE INTERFAZ
        public async Task CrearVendedor(UsuarioDto usuarioDto)
        {
            // Mapeamos el DTO a la Entidad de Dominio
            var nuevoUsuario = _mapper.Map<Usuario>(usuarioDto);

            // Asignamos el departamento por defecto para que aparezca en la lista después
            nuevoUsuario.Departamento = Departamento.Ventas;
            nuevoUsuario.Id = Guid.NewGuid(); // Aseguramos que tenga un ID nuevo

            await _usuarioRepository.AddAsync(nuevoUsuario);
        }
    }
}