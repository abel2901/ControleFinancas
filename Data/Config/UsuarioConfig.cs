using ControleFinancas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinancas.Data.Config
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasColumnName("Username");
            builder.Property(x => x.DataNascimento).HasColumnName("DataNascimento");
            builder.Property(x => x.PasswordHash).HasColumnName("Password");
            
        }
    }
}
