using AutoMapper;
using ControleFinancas.Dtos;
using ControleFinancas.Enum;
using ControleFinancas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ControleFinancas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController : Controller
    {
        private ControleFinancasContext _context;
        private IMapper _mapper;

        public ReceitaController(ControleFinancasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void AdicionaReceita([FromBody] CreateReceitaDto receitaDto)
        {
            Receita receita = _mapper.Map<Receita>(receitaDto);

            var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == receitaDto.TipoCategoria);
            var categoriaDto = _mapper.Map<ReadCategoryDto>(categoria);

            receitaDto.Valor = Convert.ToDouble(String.Format("{0:F2}", receitaDto.Valor));

            var descricao = _context.Receitas.FirstOrDefault(receita => receita.Descricao == receitaDto.Descricao);


            receita.TipoCategoria = categoriaDto.TipoCategoria;
            
            if (descricao == null)
            {
                _context.Receitas.Add(receita);

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<ReadReceitaDto> ListaTodasReceitas()
        {
            return _mapper.Map<List<ReadReceitaDto>>(_context.Receitas).ToList();
        }

        [HttpGet("/receitas/{descricao}")]
        public IEnumerable<ReadReceitaDto> BuscaReceitaPorDescricao(string descricao)
        {
            var receita = _context.Receitas.FirstOrDefault(receita => receita.Descricao == descricao);
            if(descricao == null) return Enumerable.Empty<ReadReceitaDto>();
            var receitaDto = _mapper.Map<ReadReceitaDto>(receita);
            return _mapper.Map<List<ReadReceitaDto>>(_context.Receitas).Where(receita => receita.Descricao == descricao).ToList();
        }
        
        [HttpGet("{id}")]
        public IActionResult DetalhamentoReceita(int id)
        {
            var receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if (receita == null) return NotFound();
            var receitaDto = _mapper.Map<ReadReceitaDto>(receita);
            return Ok(receitaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaReceita(int id, [FromBody] UpdateReceitaDto receitaDto)
        {
            var receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if (receita == null) return NotFound();
            _mapper.Map(receitaDto, receita);
            _context.SaveChanges();
            return NoContent();
        } 
        
        [HttpDelete("{id}")]
        public IActionResult DeletaReceita(int id)
        {
            var receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if (receita == null) return NotFound();
            _context.Remove(receita);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet("/receita/{ano}/{mes}")]
        public IEnumerable<ReadReceitaDto> ListaReceitaMensal(int ano, int mes)
        {
            var receita = _context.Despesas.FirstOrDefault();
            if (receita == null) return Enumerable.Empty<ReadReceitaDto>();
            var receitaDto = _mapper.Map<ReadReceitaDto>(receita);
            return _mapper.Map<List<ReadReceitaDto>>(_context.Receitas).Where(receita => receita.Data.Month == mes && receita.Data.Year == ano).ToList();
        }

        [HttpGet("/resumo/{ano}/{mes}")]
        public List<string> ResumoMensal(int ano, int mes)
        {
            List<string> ResumoMensal = new List<string>();

            var receita = _context.Receitas.FirstOrDefault();
            var despesa = _context.Despesas.FirstOrDefault();

            var despesaDto = _mapper.Map<ReadDespesaDto>(despesa);
            var receitaDto = _mapper.Map<ReadReceitaDto>(receita);

            var valorTotalReceitaMensal = _context.Receitas
                .Where(receita => receita.Data.Month == mes && receita.Data.Year == ano)
                .Select(receita => receita.Valor)
                .Sum();

            ResumoMensal.Add(valorTotalReceitaMensal.ToString());

            var valorTotalDespesaMensal = _context.Despesas
                .Where(despesa => despesa.Data.Month == mes && despesa.Data.Year == ano)
                .Select(despesa => despesa.Valor)
                .Sum();

            ResumoMensal.Add(valorTotalDespesaMensal.ToString());

            var saldoFinalMensal = valorTotalReceitaMensal - valorTotalDespesaMensal;

            ResumoMensal.Add(saldoFinalMensal.ToString());

            if (ResumoMensal.Count == 0) return new List<string>();

            return ResumoMensal;

            //var valorTotalDespesaPorCategoria = _context.Despesas
            //    .Where(despesa => despesa.Data.Month == mes && despesa.Data.Year == ano && despesa.TipoCategoria 
            //    .Select(despesa => despesa.Valor)
            //    .Sum();

        }
    }
}
