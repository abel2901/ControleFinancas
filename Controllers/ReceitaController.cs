using AutoMapper;
using ControleFinancas.Dtos;
using ControleFinancas.Models;
using Microsoft.AspNetCore.Mvc;

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
            var descricao = _context.Receitas.FirstOrDefault(receita => receita.Descricao == receitaDto.Descricao);
            Receita receita = _mapper.Map<Receita>(receitaDto);
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
    }
}
