using LinkDev.IKEA.DAL.persistance.Data;
using LinkDev.IKEA.DAL.persistance.Repoistories.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.IKEA.DAL.persistance.Repoistories.Employees;

namespace LinkDev.IKEA.DAL.persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
            
        }
        public IDepartmentRepoistory DepartmentRepoistory => new DepartmentRepoistory(_dbContext);

        public IEmployeeRepoistory EmplpyeeRepoistory => new  EmployeeRepoistory (_dbContext);

        public async  Task<int> CompleteAsync()
        {
           return  await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
           await _dbContext.DisposeAsync();
        }
    }
}
