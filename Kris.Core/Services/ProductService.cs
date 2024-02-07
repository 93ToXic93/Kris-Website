using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public async Task UpdateAsync(ProductModel model)
        {
            var prod = await _context.Products.FindAsync(model.Id);

            if (prod == null)
            {
                throw new ArgumentException("Not Found!");
            }

            if (await _context.Products.AnyAsync(x => x.Name == model.Name) && model.Name != prod.Name)
            {
                throw new InvalidOperationException("There is product with the same name already!");
            }


            prod.Name = model.Name;
            prod.Price = model.Price;
            prod.Category = model.Category;
            prod.Description = model.Description;

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);

            if (productToDelete == null)
            {
                throw new ArgumentException("There is no such item to delete!");
            }

            _context.Remove(productToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            Product? product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                throw new ArgumentException("The product isn't found!");
            }

            ProductModel model = new ProductModel()
            {
                Price = product.Price,
                Description = product.Description,
                Id = product.Id,
                Category = product.Category,
                Name = product.Name
            };

            return model;
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
            .AsNoTracking()
            .ToListAsync();

            return products;  
        }
    }
}
