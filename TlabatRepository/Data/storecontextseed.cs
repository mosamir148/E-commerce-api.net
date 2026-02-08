using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalabatCore.Entites;

namespace TlabatRepository.Data
{
    public static class storecontextseed
    {
        public static async Task seedasync(StoreContext dbcontext)
        {
    
            if (!dbcontext.productBrands.Any())
            {
                var branddata = File.ReadAllText("../TlabatRepository/Data/seeddata/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(branddata);
                if (brands?.Count > 0)
                {
                    foreach (var brand in brands)
                    {
                     await   dbcontext.Set<ProductBrand>().AddAsync(brand);

                    }
                   await dbcontext.SaveChangesAsync();
                }
            }

            if (!dbcontext.productTypes.Any())
            {
                var branddata = File.ReadAllText("../TlabatRepository/Data/seeddata/types.json");
                var brands = JsonSerializer.Deserialize<List<ProductType>>(branddata);
                if (brands?.Count > 0)
                {
                    foreach (var brand in brands)
                    {
                        await dbcontext.Set<ProductType>().AddAsync(brand);

                    }
                    await dbcontext.SaveChangesAsync();
                }
            }

            if (!dbcontext.products.Any())
            {
                var branddata = File.ReadAllText("../TlabatRepository/Data/seeddata/products.json");
                var brands = JsonSerializer.Deserialize<List<Product>>(branddata);
                if (brands?.Count > 0)
                {
                    foreach (var brand in brands)
                    {
                        await dbcontext.Set<Product>().AddAsync(brand);

                    }
                    await dbcontext.SaveChangesAsync();
                }
            }


        }
    }
}
