using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.Repoistories
{
    public class DepartmentRepoistory : IDepartmentRepoistory
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepoistory(ApplicationDbContext dbContext)
        {
            _dbContext =dbContext;
        }
        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Department.ToList();
        }
        public IQueryable<Department> GetAllDepartments( )
        {
            return _dbContext.Department;
        }
        public Department? GetDepartmentById(int id)
        {
           return _dbContext.Department.Find(id);
        }
        public int AddDepartment(Department entity)
        {
            _dbContext.Department.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int UpdateDepartment(Department entity)
        {
            _dbContext.Department.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int DeleteDepartment(Department entity)
        {
            _dbContext.Department.Remove(entity);
            return _dbContext.SaveChanges();
        }

        
    }
}
