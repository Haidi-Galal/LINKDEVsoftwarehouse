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
        public IEnumerable<EmployeeDto> GetEmployees();
        public EmployeeDetailsDto? GetEmployeeById(int id);
        public int CreateEmployee(CreateEmployeeDto employeeDto);
        public int UpdateEmployee(UpdatedEmployeeDto employee);
        public bool DeleteEmployee(int id);

    }
}
