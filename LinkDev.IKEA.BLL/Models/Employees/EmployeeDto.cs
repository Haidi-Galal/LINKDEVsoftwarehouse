using LinkDev.IKEA.DAL.Entities.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public int Age { get; set; }
        public string Name { get; set; } = null!;
        [DataType(DataType.Currency)]
        public int Salary { get; set; }
        [Display(Name = "Is Active")]

        public bool IsActive { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string EmployeeType { get; set; } = null!;
    }
}
