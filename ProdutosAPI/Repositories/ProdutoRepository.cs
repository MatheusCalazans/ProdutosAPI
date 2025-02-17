using ProdutosAPI.Context;
using ProdutosAPI.Entities;

namespace ProdutosAPI.Repositories
{
    public class ProdutoRepository
    {
        public void Add(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                
                if (dataContext.Set<Produto>().Any(p => p.Nome == produto.Nome))
                {
                    throw new InvalidOperationException("Já existe um produto com este nome.");
                }

                dataContext.Add(produto);
                dataContext.SaveChanges();
            }

        }
        public void Update(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(produto);
                dataContext.SaveChanges();
            }
        }
        public void Delete(Produto produto)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(produto);
                dataContext.SaveChanges();
            }
        }
        public List<Produto> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Produto>()
                    .OrderBy(p => p.Nome)
                    .ToList();
            }
        }
        public Produto GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Produto>()
                    .Find(id);
            }
        }
    }
}
