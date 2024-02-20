namespace ControleFinancas.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
