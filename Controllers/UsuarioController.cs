using ControleFinancas.Dtos;
using ControleFinancas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinancas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto) 
        { 
            await _usuarioService.Cadastra(dto);

            return Ok("Usuário cadastrado");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            await _usuarioService.Login(dto);
            return Ok("Usuario autenticado!");

        }
    }
}
