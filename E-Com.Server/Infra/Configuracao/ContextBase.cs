using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<CompraUsuario> CompraUsuario { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<LogSistema> LogSistema { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuração da tabela AspNetUsers
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            // Configuração das chaves estrangeiras para CompraUsuario
            builder.Entity<CompraUsuario>()
                .HasKey(cu => new { cu.IdCompra, cu.UserId, cu.IdProduto });

            builder.Entity<CompraUsuario>()
                .HasOne(cu => cu.Compra)
                .WithMany()
                .HasForeignKey(cu => cu.IdCompra)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CompraUsuario>()
                .HasOne(cu => cu.ApplicationUser)
                .WithMany()
                .HasForeignKey(cu => cu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CompraUsuario>()
                .HasOne(cu => cu.Produto)
                .WithMany()
                .HasForeignKey(cu => cu.IdProduto)
                .OnDelete(DeleteBehavior.Restrict);
        }


        private string GetStringConnectionConfig()
        {
            string strCon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ECommerceDb;Integrated Security=True;TrustServerCertificate=true";
            return strCon;
        }


    }
}