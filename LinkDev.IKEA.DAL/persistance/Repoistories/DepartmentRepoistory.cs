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
    internal class DepartmentRepoistory : IDepartmentRepoistory
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepoistory(ApplicationDbContext dbContext)
        {
            _dbContext =dbContext;
        }
        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments.ToList();
        }
        public IQueryable<Department> GetAllDepartments( )
        {
            return _dbContext.Departments;
        }
        public Department? GetDepartmentById(int id)
        {
           return _dbContext.Departments.Find(id);
        }
        public int AddDepartment(Department entity)
        {
            _dbContext.Departments.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int UpdateDepartment(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }

        public int DeleteDepartment(Department entity)
        {
            _dbContext.Departments.Update(entity);
            return _dbContext.SaveChanges();
        }

        
    }
}
