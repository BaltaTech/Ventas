using AutoMapper;
using Application.DTOs; // Para encontrar ProspectoDto
using Domain.Entities;  // Para encontrar Prospecto

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ==========================================
            // 1. MAPEOS DE PRODUCTO (Existentes)
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
            // 2. NUEVO: MAPEOS DE PROSPECTO (Sustituto de Google Sheets)
            // ==========================================

            // Entidad (DB) -> DTO (Pantalla)
            CreateMap<Prospecto, ProspectoDto>()
                // Convertimos el Enum Origen a string (ej. "WhatsApp")
                .ForMember(dest => dest.OrigenNombre, opt => opt.MapFrom(src => src.Origen.ToString()))
                // Accedemos a la propiedad de navegación para obtener el nombre de la empresa
                .ForMember(dest => dest.RazonSocial, opt => opt.MapFrom(src => src.Empresa.RazonSocial))
                // Obtenemos el nombre del vendedor asignado
                .ForMember(dest => dest.RazonSocial, opt => opt.MapFrom(src => src.Empresa.RazonSocial ?? "Sin Empresa"));            // DTO (Entrada de Recepción) -> Entidad (DB)
            CreateMap<ProspectoDto, Prospecto>()
                // El ID y la Fecha se manejan en el servicio o DB, los ignoramos aquí
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaRegistro, opt => opt.Ignore())
                // Nos aseguramos de mapear los IDs de relación
                .ForMember(dest => dest.EmpresaId, opt => opt.MapFrom(src => src.EmpresaId))
                .ForMember(dest => dest.VendedorId, opt => opt.MapFrom(src => src.VendedorId));
        }
    }
}