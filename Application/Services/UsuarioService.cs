using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces; // Asumiendo que crearás IUsuarioRepository
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
            // Traemos todos los usuarios desde el repositorio
            var usuarios = await _usuarioRepository.GetAllAsync();

            // Filtramos por el departamento de Ventas definido en tu Enum
            var vendedores = usuarios.Where(u => u.Departamento == Departamento.Ventas);

            // Mapeamos a DTO para enviar solo lo necesario a la UI (Id y Nombre)
            return _mapper.Map<IEnumerable<UsuarioDto>>(vendedores);
        }
    }
}