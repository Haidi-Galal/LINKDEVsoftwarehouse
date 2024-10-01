using LinkDev.IKEA.DAL.Entities.common;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.Repoistories._Generic
{
    public interface IGenericRepoistory <T> where T:ModelBase
    {
        public  IQueryable<T> GetAllIQuerable();
        public  Task< IEnumerable<T>> GetAllAsync();

        public Task<T?> GetByIdAsync(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);


    }
}
