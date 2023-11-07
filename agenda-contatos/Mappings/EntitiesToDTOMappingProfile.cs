using agenda_contatos.DTOs;
using agenda_contatos.Models;
using AutoMapper;

namespace agenda_contatos.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Contato, ContatoDTO>().ReverseMap();
            CreateMap<Usuario, AuthDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

        }
    }
}