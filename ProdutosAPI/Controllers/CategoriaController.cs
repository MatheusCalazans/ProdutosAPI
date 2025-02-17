using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.DTOs;
using ProdutosAPI.Entities;
using ProdutosAPI.Repositories;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var categoriaRepository = new CategoriaRepository();
            var categorias = categoriaRepository.GetAll();

            var response = new List<CategoriaResponseDto>();

            foreach (var categoria in categorias)
            {
                response.Add(new CategoriaResponseDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                });
            }
            return Ok(response);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CategoriaRequestDto request)
        {
            try
            {
                var categoria = new Categoria
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                };
                var categoriaRepository = new CategoriaRepository();
                categoriaRepository.Add(categoria);
                return Ok(new
                {
                    Message = "Categoria cadastrada com sucesso.",
                    CreatedAt = DateTime.Now,
                    CategoriaId = categoria.Id,
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
