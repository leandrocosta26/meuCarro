using System;

using Microsoft.EntityFrameworkCore;

namespace meuCarro.Models
{
    public class LocadouraContext : DbContext
    {
        public LocadouraContext(DbContextOptions<LocadouraContext> options) : base(options)
        {
        }

        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Funcionairo> Funcionairo { get; set; }
        public DbSet<Locacao> Locacao { get; set; }
    }
}
