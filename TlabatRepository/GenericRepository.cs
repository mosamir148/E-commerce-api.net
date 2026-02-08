using Microsoft.EntityFrameworkCore;
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
    public class GenericRepository<T> : IGenericinterface<T> where T : BaseEntity
    {

        private readonly StoreContext _dbcontext;
        public GenericRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllbyspec(ISpaseficationrepo<T> spec)
        {
            return await applyby(spec).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public async Task<T> getbyidspec(ISpaseficationrepo<T> spec)
        {
            return await applyby(spec).FirstOrDefaultAsync();
        }

        public async Task<int> getCount(ISpaseficationrepo<T> spec)
        {
            return await applyby(spec).CountAsync();
        }

        public IQueryable<T> applyby(ISpaseficationrepo<T> spec) 
        {
            return  basespecification<T>.GetQuery(_dbcontext.Set<T>(), spec);
        }

       
    }
}
