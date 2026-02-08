using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore;
using TalabatCore.Entites;
using TalabatCore.Irepository;

namespace TlabatRepository
{
    public static class basespecification<T> where T : BaseEntity
    {
        public  static IQueryable<T> GetQuery(IQueryable<T> inputquery, ISpaseficationrepo<T> spec)
        {
            var quary = inputquery;
            //dbcontext.product.orderby?.include

            if (spec.Critiria is not null)
               quary=  quary.Where(spec.Critiria);


            if (spec.Orderby is not null)
                quary = quary.OrderBy(spec.Orderby);
            if (spec.Orderbydesindeing is not null)
                quary = quary.OrderBy(spec.Orderbydesindeing);

            if (spec.ispagination)
                quary = quary.Skip(spec.skip).Take(spec.take);


            quary = spec.Includes.Aggregate(quary, (str1, str2) =>str1.Include(str2));
                return quary;
        }

    }
}
