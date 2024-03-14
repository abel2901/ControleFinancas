using ControleFinancas.Dtos;
using ControleFinancas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinancas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private CadastroService _cadastroService;

        public UsuarioController(CadastroService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto) 
        { 
            await _cadastroService.Cadastra(dto);

            return Ok("Usuário cadastrado");
        }
    }
}
