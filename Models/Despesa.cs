namespace ControleFinancas.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public string TipoCategoria { get; set; }
    }
}
