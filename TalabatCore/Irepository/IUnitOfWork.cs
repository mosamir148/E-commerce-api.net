using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;

namespace TalabatCore.Irepository
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IGenericinterface<T> Repositoe<T>() where T : BaseEntity;

        Task<int> Complete();
    }
}
