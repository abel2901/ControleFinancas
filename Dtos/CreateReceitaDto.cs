using System.ComponentModel.DataAnnotations;

namespace ControleFinancas.Dtos
{
    public class CreateReceitaDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
        public int TipoCategoria { get; set; }
    }
}
