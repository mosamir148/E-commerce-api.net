using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;

namespace TalabatCore.Irepository
{
    public interface ISpaseficationrepo<T> where T : BaseEntity
    {
        public Expression<Func<T,bool>> Critiria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> Orderby { get; set; }

        public Expression<Func<T, object>> Orderbydesindeing { get; set; }

        public int skip { get; set; }

        public int take { get; set; }

        public bool ispagination { get; set; }

    }
}
