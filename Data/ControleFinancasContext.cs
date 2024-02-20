using ControleFinancas.Data.Config;
using ControleFinancas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinancas
{
    public class ControleFinancasContext : DbContext
    {
        public ControleFinancasContext(DbContextOptions<ControleFinancasContext> options)
        : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReceitaConfig());
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
    }
}
