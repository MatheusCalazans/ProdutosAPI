using ProdutosAPI.Context;
using ProdutosAPI.Entities;

namespace ProdutosAPI.Repositories
{
    public class CategoriaRepository
    {
        public List<Categoria> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Categoria>()
                    .OrderBy(c => c.Nome)
                    .ToList();
            }
        }
        public void Add(Categoria categoria)
        {
            using (var dataContext = new DataContext())
            {
                
                if (dataContext.Set<Categoria>().Any(c => c.Nome == categoria.Nome))
                {
                    throw new InvalidOperationException("Já existe uma categoria com este nome.");
                }
                dataContext.Add(categoria);
                dataContext.SaveChanges();
            }
        }
    }
}