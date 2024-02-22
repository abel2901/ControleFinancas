using ControleFinancas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinancas.Data.Config
{
    public class ReceitaConfig : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receitas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnName("Descricao");
            builder.Property(x => x.Valor).HasColumnName("Valor");
            builder.Property(x => x.Data).HasColumnName("Data");
            builder.Property(x => x.TipoCategoria).HasColumnName("TipoCategoria");

        }
    }
}
