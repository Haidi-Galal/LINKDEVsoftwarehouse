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
        public IEnumerable<T> GetAll();

        public T? GetById(T entity);
        public int Add(T entity);
        public int Update(T entity);
        public int Delete(T entity);


    }
}
