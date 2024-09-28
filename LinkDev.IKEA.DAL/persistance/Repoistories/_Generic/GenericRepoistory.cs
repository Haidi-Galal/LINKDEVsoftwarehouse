using LinkDev.IKEA.DAL.Entities.common;
using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.persistance.Data;
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
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }
        public IQueryable<T> GetAllIQuerable()
        {
            return _dbContext.Set<T>();
        }
        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public int Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }






    }
}
