namespace ProdutosAPI.DTOs
{
    public class ProdutoResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Total { get { return Preco * Quantidade; } }
        public Guid? CategoriaId { get; set; }
    }
}
