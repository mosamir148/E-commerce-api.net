using TalabatCore;
using TalabatCore.Entites;

namespace Talabat.Helpres
{
    public class productparamandbrandtype : Specificationrepo<Product>
    {
        public productparamandbrandtype(paramgetallproducts para) :base(
                p =>
            (string.IsNullOrEmpty(para.Scerch) || p.Name.ToLower().Contains(para.Scerch))&&
            (!para.brands.HasValue || p.ProductBrandId == para.brands.Value) &&
            (!para.types.HasValue || p.ProductTypeId == para.types.Value)

            )
        {
            
        }
    }
}
