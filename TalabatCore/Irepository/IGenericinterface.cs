using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;

namespace TalabatCore.Irepository
{
    public interface IGenericinterface<T>  where T : BaseEntity
    {

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllbyspec(ISpaseficationrepo<T> spec);
        Task<T> getbyidspec(ISpaseficationrepo<T> spec);

        Task<int> getCount(ISpaseficationrepo<T> spec);

    }
}
