using System.ComponentModel.DataAnnotations;

namespace ControleFinancas.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Senha errada. Tente outra vez!")]
        public string ConfirmPassword { get; set;}
    }
}
