using System.ComponentModel.DataAnnotations;

namespace ProdutosAPI.DTOs
{
    public class CategoriaRequestDto
    {
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [MinLength(4, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome da categoria.")]
        public string? Nome { get; set; }
       
    }
}
