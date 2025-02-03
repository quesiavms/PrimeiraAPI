using API._1.Domain.DTOs;
using API._1.Domain.Models;
using AutoMapper;

namespace API._1.Application.Mapping
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.Nome, m => m.MapFrom(orig => orig.Nome));
        }
    }
}
