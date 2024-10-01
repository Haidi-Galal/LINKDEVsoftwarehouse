using LinkDev.IKEA.BLL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<DepartmentToReturnDto>> GetDepartmentsAsync();
        public Task<DepartmentDetailsDto?> GetDepartmentByIdAsync(int id);
        public Task<int> CreateDepartmentAsync(CreatedDepartmentDto department);
        public Task<int>  UpdateDepartmentAsync(UpdatedDepartmentDto departmentDto);
        public Task<bool> DeleteDepartmentAsync(int id);

    }
}
