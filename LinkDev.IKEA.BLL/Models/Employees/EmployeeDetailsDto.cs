using LinkDev.IKEA.DAL.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Employees
{
    public class EmployeeDetailsDto
    {
        public int Age { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Salary { get; set; }
        public bool IsActive { get; set; }
        public string EmailAddress { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        #region AdministrationData
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        #endregion
    }
}
