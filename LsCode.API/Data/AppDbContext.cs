using LsCode.API.Models; // Ajuste o namespace dos seus modelos conforme o seu projeto
using Microsoft.EntityFrameworkCore;


namespace SeuProjeto.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Dimensao> Dimensoes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.Caixas)
            .WithOne()
            .HasForeignKey(c => c.PedidoId);

        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.Produtos)
            .WithOne()
            .HasForeignKey(p => p.PedidoId);

        // Configure Dimensao se necessário
        modelBuilder.Entity<Caixa>()
            .OwnsOne(c => c.Dimensoes);

        modelBuilder.Entity<Produto>()
            .OwnsOne(p => p.Dimensoes);
        }
        
    }
}
