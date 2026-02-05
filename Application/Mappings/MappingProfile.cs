using AutoMapper;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        //Mapeo Unidireccional

        public MappingProfile()
        {
            CreateMap<Producto, ProductoDto>()
                // 1. Mapeamos 'Modelo' de la base de datos a 'Nombre' del JSON
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Modelo))

                // 2. Mapeamos el nombre de la marca (requiere el .Include en el repositorio)
                .ForMember(dest => dest.NombreMarca, opt => opt.MapFrom(src => src.Marca.Nombre))

               // 3. Si tienes un campo precio y en la entidad se llama diferente, ajústalo aquí
               // .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))

               .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.PrecioFinal));
        }   

    }
}
