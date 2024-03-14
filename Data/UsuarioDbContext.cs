using ControleFinancas.Data.Config;
using ControleFinancas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControleFinancas.Data
{
    public class UsuarioDbContext : IdentityDbContext<Usuario>
    {

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);

        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
