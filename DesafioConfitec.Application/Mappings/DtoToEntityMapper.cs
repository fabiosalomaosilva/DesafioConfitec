using AutoMapper;
using DesafioConfitec.Domain.Entities;
using DesafioConfitec.Services.Dtos;

namespace DesafioConfitec.Services.Mappings
{
    public class DtoToEntityMapper : Profile
    {
        public DtoToEntityMapper()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}