using System.Collections.Generic;
using System.Threading.Tasks;
using core.Entities;
using core.Interfaces;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;

        }

        public async  Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
           return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductbyIdAsync(int id)
        {
            var product = await _context.Products
                         .Include(p=>p.ProductBrand)
                         .Include(p=>p.ProductType)
                         .FirstOrDefaultAsync(p=>p.Id ==id);
            return product;
        }

        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            return await _context.Products
                        .Include(p=>p.ProductBrand)
                        .Include(p=>p.ProductType)
                        .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}