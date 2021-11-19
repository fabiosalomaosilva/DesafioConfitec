using AutoMapper;
using DesafioConfitec.Domain.Entities;
using DesafioConfitec.Services.Dtos;

namespace DesafioConfitec.Services.Mappings
{
    public class EntityToDtoMapper : Profile
    {
        public EntityToDtoMapper()
        {
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}