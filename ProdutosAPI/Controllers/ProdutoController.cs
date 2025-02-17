using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.DTOs;
using ProdutosAPI.Entities;
using ProdutosAPI.Repositories;

namespace ProdutosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequestDto request)
        {
            try
            {
                var produto = new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Preco = request.Preco,
                    Quantidade = request.Quantidade,
                    CategoriaId = request.CategoriaId,
                };

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Add(produto);

                return Ok(new
                {
                    Message = "Produto cadastrado com sucesso.",
                    CreatedAt = DateTime.Now,
                    ProdutoId = produto.Id,
                });
            }

            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProdutoRequestDto request)
        {
            var produtoRepository = new ProdutoRepository();
            var produto = produtoRepository.GetById(id);

            produto.Nome = request.Nome;
            produto.Preco = request.Preco;
            produto.Quantidade = request.Quantidade;
            produto.CategoriaId = request.CategoriaId;

            produtoRepository.Update(produto);
            return Ok(new
            {
                Message = "Produto atualizado com sucesso.",
                UpdatedAt = DateTime.Now,
                ProdutoId = id,
            });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var produtoRepository = new ProdutoRepository();
            var produto = produtoRepository.GetById(id);

            produtoRepository.Delete(produto);
            return Ok(new
            {
                Message = "Produto excluído com sucesso.",
                DeletedAt = DateTime.Now,
                ProdutoId = id,
            });
        }
        [HttpGet]
        public IActionResult Get()
        {
            var produtoRepository = new ProdutoRepository();
            var produtos = produtoRepository.GetAll();

            var response = new List<ProdutoResponseDto>();
            foreach (var produto in produtos)
            {
                response.Add(new ProdutoResponseDto
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    CategoriaId = produto.CategoriaId,
                });
            }
            return Ok(response);
        }
        

    }
}
