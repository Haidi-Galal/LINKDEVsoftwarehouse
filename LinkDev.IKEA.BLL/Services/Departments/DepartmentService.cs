using LinkDev.IKEA.BLL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.IKEA.DAL.persistance.Repoistories;
using LinkDev.IKEA.DAL.Entities.Department;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepoistory _departmentRepoistory;
        public DepartmentService(IDepartmentRepoistory departmentRepoistory)
        {
            _departmentRepoistory = departmentRepoistory;
        }
        public IEnumerable<DepartmentToReturnDto> GetDepartments()
        {
            return _departmentRepoistory.GetAllDepartments().Select(D =>
            new DepartmentToReturnDto 
            
            {
                Description=D.Description,
                Name= D.Name,
                Code=D.Code,
                CreationDate=D.CreationDate

                
            }




            ).ToList();

        }
        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
           var department= _departmentRepoistory.GetDepartmentById(id);
            if (department is not null)
                return new DepartmentDetailsDto
                {
                    Code = department.Code,
                    Id = department.Id,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    Description = department.Description,
                    Name = department.Name,
                    IsDeleted = department.IsDeleted,
                    LastModifiedBy = 1,
                    LastModifiedOn = department.LastModifiedOn,


                };
            else
                return null;



        }
        public int CreateDepartment(CreatedDepartmentDto department)
        {
            var createddepartment = new Department()
            {
                Code = department.Code,

                CreatedBy = 1,
                // CreatedOn = ,
                Description = department.Description,
                Name = department.Name,
                IsDeleted = false,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,

            };
           return  _departmentRepoistory.AddDepartment(createddepartment);
        }
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var updateddepartment = new Department()
            {
                Code = departmentDto.Code,
                Id= departmentDto.Id,
                CreatedBy = 1,
                // CreatedOn = ,
                Description = departmentDto.Description,
                Name = departmentDto.Name,
                IsDeleted = false,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,

            };
            return _departmentRepoistory.UpdateDepartment(updateddepartment);
        }
        public bool DeleteDepartment(int id)
        {
           var department= _departmentRepoistory.GetDepartmentById(id);
            if (department is not null)
            return _departmentRepoistory.DeleteDepartment(department) > 0;

            return false;
           
        }

    }
}
