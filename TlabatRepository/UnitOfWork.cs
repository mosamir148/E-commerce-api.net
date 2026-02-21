using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;
using TalabatCore.Irepository;
using TlabatRepository.Data;

namespace TlabatRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _dbcontext;
        private Dictionary<string, object> _repository;

        public UnitOfWork(StoreContext dbcontext)
        {
            this._dbcontext = dbcontext;
            _repository = new Dictionary<string, object>(); 
        }
        public IGenericinterface<T> Repositoe<T>() where T : BaseEntity
        {
         var type = typeof(T).Name;
            if(!_repository.ContainsKey(type))
            {
                var repo = new GenericRepository<T>(_dbcontext);
                _repository.Add(type, repo);    
               
            }
            return _repository[type] as IGenericinterface<T>;
        }

        public async Task<int> Complete() => await _dbcontext.SaveChangesAsync();

        public async ValueTask DisposeAsync()=> await _dbcontext.DisposeAsync();

        
    }
}
