using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Entities;
using ShopOnline.Api.Repositories.Contracts;

namespace ShopOnline.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
        {
            this.ShopOnlineDbContext = shopOnlineDbContext;
        }

        public ShopOnlineDbContext ShopOnlineDbContext { get; }

        public Task<ProductCategory> GetCategorie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.ShopOnlineDbContext.ProductCategories.ToListAsync();

            return categories;
        }

        public Task<Product> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await ShopOnlineDbContext.Products.ToListAsync();

            return products;
        }
    }
}
