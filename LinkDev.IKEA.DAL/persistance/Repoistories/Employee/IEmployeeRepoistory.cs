using LinkDev.IKEA.DAL.Entities.Employee;
using LinkDev.IKEA.DAL.persistance.Repoistories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.Repoistories.Employees
{
    public interface IEmployeeRepoistory:IGenericRepoistory<Employee>
    {
    }
}
