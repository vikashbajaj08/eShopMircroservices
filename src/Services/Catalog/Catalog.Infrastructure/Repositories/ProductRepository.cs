using Catalog.Domain.Entities;
using Catalog.Domain.Interface;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext context;

        public ProductRepository(CatalogDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await context.Products.FindAsync(id);
        }
        public async Task Add(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public async Task Delete(int id)
        {
            var product =
                 await context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

            if (product != null)
            {
                context.Products.Remove(product);
            }
        }


        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

    }
}
