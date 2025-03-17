using CrudOperationApi.Domain.Common.QueryParameters;
using CrudOperationApi.Domain.Entities;
using CrudOperationApi.Domain.Interfaces;
using CrudOperationApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CrudOperationApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;

        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(ProductQueryParameters queryParams)
        {
            var query=  _context.Products.AsQueryable();

            
            if (!string.IsNullOrWhiteSpace(queryParams.Search))
            {
                var searchLower = queryParams.Search.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(searchLower) ||
                                         p.Category.ToLower().Contains(searchLower));
            }

            
            query = query.Skip((queryParams.PageNumber - 1) * queryParams.ValidatedPageSize).Take(queryParams.ValidatedPageSize);

            return await query.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
