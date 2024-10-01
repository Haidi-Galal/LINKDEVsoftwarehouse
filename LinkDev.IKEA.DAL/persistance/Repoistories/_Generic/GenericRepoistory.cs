using LinkDev.IKEA.DAL.Entities.common;
using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.Repoistories._Generic
{
    public class GenericRepoistory <T> where T : ModelBase
    {
        private protected readonly ApplicationDbContext _dbContext;
        public GenericRepoistory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task< IEnumerable<T>> GetAllAsync()
        {
            return  await _dbContext.Set<T>().ToListAsync();
        }
        public IQueryable<T> GetAllIQuerable()
        {
            return _dbContext.Set<T>();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }






    }
}
