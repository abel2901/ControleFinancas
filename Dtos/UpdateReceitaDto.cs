namespace ControleFinancas.Dtos
{
    public class UpdateReceitaDto
    {
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public DateTime Data { get; set; }
        public int TipoCategoria { get; set; }
    }
}
