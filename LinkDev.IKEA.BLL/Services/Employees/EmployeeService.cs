using LinkDev.IKEA.BLL.Models.Employees;
using LinkDev.IKEA.DAL.Entities.Employee;
using LinkDev.IKEA.DAL.persistance.Repoistories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepoistory _employeeRepoistory;
        public EmployeeService(IEmployeeRepoistory employeeRepoistory)
        {
            _employeeRepoistory = employeeRepoistory;
            
        }
        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = new Employee() 
            {  Salary= employeeDto.Salary,
               PhoneNumber= employeeDto.PhoneNumber,
               Name= employeeDto.Name,
               HiringDate= employeeDto.HiringDate,
               IsActive= employeeDto.IsActive,
               Gender= employeeDto.Gender,
               EmployeeType= employeeDto.EmployeeType,
               EmailAddress= employeeDto.EmailAddress,
               Age= employeeDto.Age,
               Address= employeeDto.Address,
               CreatedBy=1,
               IsDeleted = false,
               LastModifiedBy = 1,
               LastModifiedOn = DateTime.Now,



            };


           return _employeeRepoistory.Add(employee);
           
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepoistory.GetById(id);
            if (employee is { })
                return _employeeRepoistory.Delete(employee) > 0;


        return false;

        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee= _employeeRepoistory.GetById(id);
            if (employee is { })

                return new EmployeeDetailsDto() 
                {  Address=employee.Address,
                   Age=employee.Age,
                   CreatedBy=employee.CreatedBy,
                   CreatedOn=employee.CreatedOn,
                   EmailAddress=employee.EmailAddress,
                   EmployeeType=employee.EmployeeType,
                   Gender=employee.Gender,
                   HiringDate=employee.HiringDate,
                   IsActive=employee.IsActive,
                   LastModifiedOn = employee.LastModifiedOn,
                   Name=employee.Name,
                   PhoneNumber=employee.PhoneNumber,
                   Salary=employee.Salary,
                   
                   

                
                
                
                };

            return null;

        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
           return  _employeeRepoistory.GetAllIQuerable().Select
                 (E => new EmployeeDto()
                 {
                     EmailAddress=E.EmailAddress,
                     Name=E.Name,
                     Salary=E.Salary,
                     Age=E.Age,
                     EmployeeType=E.EmployeeType.ToString(),
                     Gender=E.Gender.ToString(),
                     IsActive=E.IsActive
                   
                     

                 }).ToList();
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDto)
        {
           return _employeeRepoistory.Update(new Employee()
            {
                Id = employeeDto.Id,
                Address = employeeDto.Address,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate,
                Name = employeeDto.Name,
                PhoneNumber= employeeDto.PhoneNumber,
                Age=employeeDto.Age,
                EmployeeType=employeeDto.EmployeeType,
                Salary=employeeDto.Salary,
                IsActive=employeeDto.IsActive,
                EmailAddress=employeeDto.EmailAddress,
                CreatedBy = 1,
                IsDeleted = false,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now
                
                




            });

        }
    }
}
