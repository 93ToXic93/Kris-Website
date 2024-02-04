using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kris.Core.Contracts;
using Kris.Models;

namespace Kris.Core.Services
{
    public class ProductService : IProductService
    {
        public Task AddAsync(ProductModel product)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
