using AutoMapper;
using ControleFinancas.Dtos;
using ControleFinancas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinancas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DespesaController : Controller
    {
        private ControleFinancasContext _context;
        private IMapper _mapper;

        public DespesaController(ControleFinancasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpPost]
        public void AdicionaDespesa([FromBody] CreateDespesaDto despesaDto)
        {
            var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == despesaDto.TipoCategoria);
            var categoriaDto = _mapper.Map<ReadCategoryDto>(categoria);

            var descricao = _context.Despesas.FirstOrDefault(despesa => despesa.Descricao == despesaDto.Descricao);

            Despesa despesa = _mapper.Map<Despesa>(despesaDto);

            despesa.TipoCategoria = categoriaDto.TipoCategoria;

            if (descricao == null)
            {
                _context.Despesas.Add(despesa);

                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<ReadDespesaDto> ListaTodasDespesas()
        {
            return _mapper.Map<List<ReadDespesaDto>>(_context.Despesas).ToList();
        }

        [HttpGet("/despesas/{descricao}")]
        public IEnumerable<ReadDespesaDto> BuscaDespesaPorDescricao(string descricao)
        {
            var despesa = _context.Despesas.FirstOrDefault(despesa => despesa.Descricao == descricao);
            if (despesa == null) return Enumerable.Empty<ReadDespesaDto>();
            var despesaDto = _mapper.Map<ReadDespesaDto>(despesa);
            return _mapper.Map<List<ReadDespesaDto>>(_context.Despesas).Where(despesa => despesa.Descricao == descricao).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult DetalhamentoDespesa(int id)
        {
            var despesa = _context.Despesas.FirstOrDefault(despesa => despesa.Id == id);
            if(despesa == null) return NotFound();
            var despesaDto = _mapper.Map<ReadDespesaDto>(despesa);
            return Ok(despesaDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDespesa(int id, [FromBody] UpdateDespesaDto despesaDto)
        {
            var despesa = _context.Despesas.FirstOrDefault(depesa => depesa.Id == id);
            if (despesa == null) return NotFound();
            _mapper.Map(despesaDto, despesa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaDespesa(int id)
        {
            var despesa = _context.Despesas.FirstOrDefault(depesa => depesa.Id == id);
            if (despesa == null) return NotFound();
            _context.Remove(despesa);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
