using LinkDev.IKEA.BLL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    internal interface IDepartmentService
    {
        public IEnumerable<DepartmentToReturnDto> GetDepartments();
        public DepartmentDetailsDto? GetDepartmentById(int id);
        public int CreateDepartment(CreatedDepartmentDto department);
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto);
        public bool DeleteDepartment(int id);

    }
}
