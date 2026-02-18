using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ==========================================
            // 1. MAPEOS DE PRODUCTO
            // ==========================================
            CreateMap<Producto, ProductoDto>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.NombreMarca, opt => opt.MapFrom(src => src.Marca.Nombre))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.PrecioFinal))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
                .ForMember(dest => dest.Tonelaje, opt => opt.MapFrom(src => src.Tonelaje));

            CreateMap<ProductoDto, Producto>()
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Nombre))
                .ForPath(dest => dest.Marca.Nombre, opt => opt.Ignore());

            // ==========================================
            // 2. MAPEOS DE PROSPECTO (CORREGIDO)
            // ==========================================

            // Entidad (DB) -> DTO (Pantalla)
            CreateMap<Prospecto, ProspectoDto>()
                .ForMember(dest => dest.OrigenNombre, opt => opt.MapFrom(src => src.Origen.ToString()))
                // Mapeo de Empresa (Evita el null si no hay empresa relacionada)
                .ForMember(dest => dest.RazonSocial, opt => opt.MapFrom(src => src.Empresa != null ? src.Empresa.RazonSocial : "Sin Empresa"))
                // Mapeo de Vendedor: Aquí estaba el error. Mapeamos desde la relación "Vendedor"
                .ForMember(dest => dest.NombreVendedor, opt => opt.MapFrom(src => src.Vendedor != null ? src.Vendedor.NombreCompleto : "Sin Asignar"));

            // DTO (Entrada de Recepción) -> Entidad (DB)
            CreateMap<ProspectoDto, Prospecto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaRegistro, opt => opt.Ignore())
                // El VendedorId es vital para que la relación se guarde en DB
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom(src => src.EmpresaId))
                .ForMember(dest => dest.VendedorId, opt => opt.MapFrom(src => src.VendedorId));

            // ==========================================
            // 3. OTROS MAPEOS
            // ==========================================
            CreateMap<Empresa, EmpresaDto>();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}