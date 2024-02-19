using System.ComponentModel.DataAnnotations;

namespace ControleFinancas.Dtos
{
    public class CreateReceitaDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}
