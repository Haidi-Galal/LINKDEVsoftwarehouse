using LinkDev.IKEA.BLL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.persistance.Repoistories.Departments;
using LinkDev.IKEA.DAL.persistance.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.IKEA.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public  async Task<IEnumerable<DepartmentToReturnDto>> GetDepartmentsAsync()
        {
           var depts= await  _unitOfWork.DepartmentRepoistory.GetAllIQuerable().Select(D =>
             new DepartmentToReturnDto 
            
            {   Id=D.Id,
                Description=D.Description,
                Name= D.Name,
                Code=D.Code,
                CreationDate=D.CreationDate

                
            }




            ).ToListAsync();
            return depts;
        }
        public async Task< DepartmentDetailsDto?> GetDepartmentByIdAsync(int id)
        {
           var department= await _unitOfWork.DepartmentRepoistory.GetByIdAsync(id);
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
                    CreationDate=department.CreationDate


                };
            else
                return null;



        }
        public async Task< int> CreateDepartmentAsync(CreatedDepartmentDto department)
        {
            var createddepartment = new Department()
            {
                Code = department.Code,

                CreatedBy = 1,
                CreationDate=department.CreationDate,
                Description = department.Description,
                Name = department.Name,
                IsDeleted = false,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,

            };
            _unitOfWork.DepartmentRepoistory.Add(createddepartment);

            return await  _unitOfWork.CompleteAsync();
        }
        public async   Task<int> UpdateDepartmentAsync(UpdatedDepartmentDto departmentDto)
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
            _unitOfWork.DepartmentRepoistory.Update(updateddepartment);
            return await _unitOfWork.CompleteAsync();
        }
        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var repo = _unitOfWork.DepartmentRepoistory;
           var department=await  repo.GetByIdAsync(id);
            if (department is not null)
             repo.Delete(department) ;
            return await _unitOfWork.CompleteAsync()>0;
           
        }

    }
}
