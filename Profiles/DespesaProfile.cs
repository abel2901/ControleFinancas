using AutoMapper;
using ControleFinancas.Dtos;
using ControleFinancas.Models;

namespace ControleFinancas.Profiles
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<CreateDespesaDto, Despesa>();
            CreateMap<Despesa, ReadDespesaDto>();
            CreateMap<ReadCategoryDto, Despesa>();
        }
    }
}
