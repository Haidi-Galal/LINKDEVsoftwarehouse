using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.IKEA.DAL.Entities.common;

namespace LinkDev.IKEA.DAL.Entities.Employee
{
    public class Employee:ModelBase
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

    }
}
