using AutoMapper;
using ControleFinancas.Dtos;
using ControleFinancas.Models;

namespace ControleFinancas.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, ReadCategoryDto>();
        }
    }
}
