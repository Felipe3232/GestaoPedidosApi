

using GestaoPedidosAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidosAPI.Data.Context 
{
    public class GestaoPedidosDbContext : DbContext
    {

        public GestaoPedidosDbContext(DbContextOptions<GestaoPedidosDbContext> options): base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Protocolo> Protocolos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cliente>()
                .ToTable("Cliente");

            builder.Entity<Endereco>()
                .ToTable("Endereco");

            builder.Entity<Protocolo>()
                .ToTable("Protocolo");

            builder.Entity<Pessoa>()
                .ToTable("Pessoa");

            builder.Entity<Solicitacao>()
                .ToTable("Solicitacao");

        }
    }

}

