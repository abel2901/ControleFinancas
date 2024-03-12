using Microsoft.AspNetCore.Identity;

namespace ControleFinancas.Models
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        public Usuario(): base() { }
    }
}
