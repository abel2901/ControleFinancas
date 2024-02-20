using ControleFinancas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinancas.Data.Config
{
    public class DespesaConfig : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("Despesas");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasColumnName("Descricao");
            builder.Property(x => x.Valor).HasColumnName("Valor");
            builder.Property(x => x.Data).HasColumnName("Data");

        }
    }
}
