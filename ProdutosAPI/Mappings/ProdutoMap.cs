using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosAPI.Entities;

namespace ProdutosAPI.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTOS");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(p => p.Nome)
                .IsUnique();

            builder.Property(p => p.Preco)
                .HasColumnName("PRECO")
                .HasColumnType("DECIMAL(10,2)")
                .IsRequired();

            builder.Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(p => p.CategoriaId)
                .HasColumnName("CATEGORIAID")
                .IsRequired();

            builder.HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
