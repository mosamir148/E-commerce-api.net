using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Helpres;
using TalabatCore.Entites;

namespace TalabatCore
{
    public class specificatiobrandandtye :Specificationrepo<Product> 
    {
        public specificatiobrandandtye(paramgetallproducts para) :base(
            p =>
            (string.IsNullOrEmpty(para.Scerch) || p.Name.ToLower().Contains(para.Scerch)) &&
            (!para.brands.HasValue || p.ProductBrandId == para.brands.Value) &&
            (!para.types.HasValue || p.ProductTypeId == para.types.Value)

            )
        {
           

           // Orderby = x => x.Name;

            if(!string.IsNullOrEmpty(para.sort))
            {
                switch (para.sort)
                {
                    case "PriceAsc":
                        Orderby = p => p.Price;
                        break;
                    case "pricedes":
                        Orderbydesindeing = p => p.Price;
                        break;
                    default:
                        Orderby = p => p.Name;
                        break;

                }
            }
            //index =2
            //5

            getpagination( para.Pagesize * (para.indexpage - 1), para.Pagesize);

        }

        public specificatiobrandandtye(int id):base(i => i.Id == id)
        {
            Includes.Add(x => x.ProductBrand);
            Includes.Add(y => y.ProductType);
        }


    }
}
