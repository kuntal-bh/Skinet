using core.Entities;

namespace core.Specifications
{
    public class ProductWithBrandsAndTypes:Specification<Product>
    {
        public ProductWithBrandsAndTypes()
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }

        public ProductWithBrandsAndTypes(int id ):base(x=>x.Id ==id)
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}