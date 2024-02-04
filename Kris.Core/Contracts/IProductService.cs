using Kris.Infrastructure.Data.Models;
using Kris.Models;

namespace Kris.Core.Contracts
{
    public interface IProductService
    {
        Task AddAsync(ProductModel model);

        Task UpdateAsync(ProductModel model);

        Task DeleteAsync(int id);

        Task<ProductModel> GetProductByIdAsync(int id);

        Task<IEnumerable<ProductModel>> GetAllAsync();
    }

}
