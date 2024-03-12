using AutoMapper;
using ControleFinancas.Dtos;
using ControleFinancas.Models;

namespace ControleFinancas.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
