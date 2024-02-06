using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kris.Core.Contracts;
using Kris.Infrastructure.Data;
using Kris.Infrastructure.Data.Models;
using Kris.Models;
using Microsoft.EntityFrameworkCore;

namespace Kris.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly KrisDbContext _context;

        public ProductService(KrisDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductModel product)
        {

            if (_context.Products.Any(x => x.Name == product.Name))
            {
                throw new ArgumentException("There is already the same product!");
            }


            Product productToAdd = new Product()
            {
                Name = product.Name,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
                Id = product.Id
            }; 

            await _context.Products.AddAsync(productToAdd);

            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var products = await _context.Products.Select(x => new ProductModel()
            {
                Name = x.Name,
                Category = x.Category,
                Price = x.Price,
                Description = x.Description,
                Id = x.Id
            })
            .ToListAsync();

            return products;  
        }
    }
}
