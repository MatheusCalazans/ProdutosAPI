using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ProdutosAPI.Entities;

namespace ProdutosAPI.DTOs
{
    public class ProdutoRequestDto
    {
        [MaxLength(50, ErrorMessage ="Informe no máximo {1} caracteres.")]
        [MinLength(4, ErrorMessage ="Informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage ="Por favor, informe o nome do produto.")]
        public string? Nome { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Favor informe o preço entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor informe o preço do produto.")]
        public Decimal? Preco { get; set; }

        [Range(1, 99999, ErrorMessage = "Favor, informe a quantidade entre {1}e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage ="Por favor, informe a categoria do produto.")]
        public Guid? CategoriaId { get; set; }


    }
}
