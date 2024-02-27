namespace ControleFinancas.Dtos
{
    public class ReadReceitaDto
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public string TipoCategoria { get; set; }
    }
}
