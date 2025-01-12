using Catalog.Domain.Entities;

namespace Catalog.Domain.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
        Task<int> SaveChangesAsync();
    }
}
