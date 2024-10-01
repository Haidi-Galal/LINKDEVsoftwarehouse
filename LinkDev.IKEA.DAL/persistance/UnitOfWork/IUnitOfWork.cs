using LinkDev.IKEA.DAL.persistance.Repoistories.Departments;
using LinkDev.IKEA.DAL.persistance.Repoistories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IDepartmentRepoistory DepartmentRepoistory { get;  }
        public IEmployeeRepoistory EmplpyeeRepoistory { get; }

        public  Task<int> CompleteAsync();
        public ValueTask DisposeAsync();
        
    }
}
