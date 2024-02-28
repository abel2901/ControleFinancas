using ControleFinancas.Models;

namespace ControleFinancas.Dtos
{
    public class ReadDespesaDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string TipoCategoria { get; set; }

    }
}
