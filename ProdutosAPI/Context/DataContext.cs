using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Mappings;

namespace ProdutosAPI.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=master;User ID=sa;Password=DESAFIO@2025;Encrypt=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
    
}
