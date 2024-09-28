using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.persistance.Data;
using LinkDev.IKEA.DAL.persistance.Repoistories._Generic;
using LinkDev.IKEA.DAL.persistance.Repoistories.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.Repoistories.Departments
{
    public class DepartmentRepoistory : GenericRepoistory<Department>, IDepartmentRepoistory
    {
        public DepartmentRepoistory(ApplicationDbContext dbContext) :base(dbContext)
        {
            
        }

    }
}
