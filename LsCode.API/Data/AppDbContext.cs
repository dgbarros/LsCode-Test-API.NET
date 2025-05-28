using LsCode.API.Models; // Ajuste o namespace dos seus modelos conforme o seu projeto
using Microsoft.EntityFrameworkCore;


namespace SeuProjeto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Dimensao> Dimensoes { get; set; }
    }
}
