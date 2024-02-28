namespace ControleFinancas.Dtos
{
    public class UpdateDespesaDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int TipoCategoria { get; set; }
    }
}
