using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System;

namespace infrastructure.Data
{
    public class StoreSeedContext
    {
        public static async Task SeedContextAsync (DataContext context , ILoggerFactory factory) {
            try
            {
                if(!context.ProductBrands.Any()) 
                {
                    var productBrands = File.ReadAllText("../infrastructure/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrands);
                    foreach (var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.ProductTypes.Any()) 
                {
                    var ProductTypes = File.ReadAllText("../infrastructure/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(ProductTypes);
                    foreach (var type in types)
                    {
                        context.ProductTypes.Add(type);
                    }
                    await context.SaveChangesAsync();
                }

                 if(!context.Products.Any()) 
                {
                    var Products = File.ReadAllText("../infrastructure/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(Products);
                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {
                
              var logger = factory.CreateLogger<StoreSeedContext>();
              logger.LogError(ex,"An exception occured while loading Data");
            }
        }
    }
}