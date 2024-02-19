using AutoMapper;
using ControleFinancas.Dtos;
using ControleFinancas.Models;

namespace ControleFinancas.Profiles
{
    public class ReceitaProfile : Profile
    {
        public ReceitaProfile()
        {
            CreateMap<CreateReceitaDto, Receita>();
            CreateMap<Receita, ReadReceitaDto>();
        }
    }
}
