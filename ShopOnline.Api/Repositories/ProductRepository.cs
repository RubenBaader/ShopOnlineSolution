﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await this.ShopOnlineDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.ShopOnlineDbContext.ProductCategories.ToListAsync();

            return categories;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await ShopOnlineDbContext.Products
                                .Include(p => p.ProductCategory)
                                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await ShopOnlineDbContext.Products
                                .Include(p => p.ProductCategory)                
                                .ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            var products = await ShopOnlineDbContext.Products
                                .Include(p => p.ProductCategory)
                                .Where(p => p.CategoryId == id)
                                .ToListAsync();
            return products;
        }
    }
}
