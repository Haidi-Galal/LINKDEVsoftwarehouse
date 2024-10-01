using LinkDev.IKEA.BLL.Models.Departments;
using LinkDev.IKEA.BLL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        public Task<EmployeeDetailsDto?> GetEmployeeByIdAsync(int id);
        public Task<int> CreateEmployeeAsync(CreateEmployeeDto employeeDto);
        public Task<int> UpdateEmployeeAsync(UpdatedEmployeeDto employee);
        public Task<bool> DeleteEmployeeAsync(int id);

    }
}
