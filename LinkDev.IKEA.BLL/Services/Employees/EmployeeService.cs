﻿using LinkDev.IKEA.BLL.Models.Employees;
using LinkDev.IKEA.DAL.Entities.Employee;
using LinkDev.IKEA.DAL.persistance.Repoistories.Employees;
using LinkDev.IKEA.DAL.persistance.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UnitOfWork _unitOfWork;
        public EmployeeService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
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


            _unitOfWork.EmplpyeeRepoistory.
                Add(employee);
            return _unitOfWork.Complete();


        }

        public bool DeleteEmployee(int id)
        {
            var employee = _unitOfWork.EmplpyeeRepoistory.GetById(id);
            if (employee is { })
             _unitOfWork.EmplpyeeRepoistory.Delete(employee) ;


        return _unitOfWork.Complete()> 0;

        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee= _unitOfWork.EmplpyeeRepoistory.GetById(id);
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
           return _unitOfWork.EmplpyeeRepoistory.GetAllIQuerable().Select
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
            _unitOfWork.EmplpyeeRepoistory.Update(new Employee()
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
            return _unitOfWork.Complete();

        }
    }
}
