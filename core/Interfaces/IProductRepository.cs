using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;

namespace core.Interfaces
{
    public interface IProductRepository
    {
         Task<Product> GetProductbyIdAsync(int id);
         Task<IReadOnlyList<Product>> GetProducts();
         
    }
}