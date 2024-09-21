using LinkDev.IKEA.DAL.Entities.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.Repoistories
{
    public interface IDepartmentRepoistory
    {
        public IEnumerable<Department> GetAll();
        public IQueryable<Department> GetAllDepartments();

        public Department? GetDepartmentById(int id);
        public int AddDepartment(Department entity);
        public int UpdateDepartment(Department entity);
        public int DeleteDepartment(Department entity);
    }
}
