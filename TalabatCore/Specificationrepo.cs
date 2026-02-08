using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;
using TalabatCore.Irepository;

namespace TalabatCore
{
    public class Specificationrepo<T> : ISpaseficationrepo<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Critiria { get ; set; }
        public List<Expression<Func<T,object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> Orderby { get; set; }
        public Expression<Func<T, object>> Orderbydesindeing { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public bool ispagination { get; set; }

        public Specificationrepo()
        {
           
        }

        public Specificationrepo(Expression<Func<T,bool>> critirea)
        {
            Critiria = critirea;
        }

        public void getpagination(int skip,int take)
        {
            ispagination = true;
            this.take = take;
            this.skip =skip;    

        }
    }
}
