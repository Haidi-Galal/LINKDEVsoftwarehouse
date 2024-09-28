using LinkDev.IKEA.DAL.Entities.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Employees
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; }
        [Range(20, 50)]

        public int Age { get; set; }
        [MaxLength(50, ErrorMessage = "You exceeded Max Length")]
        [MinLength(5, ErrorMessage = "min is 5 characters")]

        public string Name { get; set; } = null!;
        [RegularExpression(@"^[a-zA-Z0-9\s,.'-]{3,100}$", ErrorMessage = "Please enter a valid address.")]

        public string Address { get; set; } = null!;
        public int Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]

        public string EmailAddress { get; set; } = null!;
        [Phone]
        public int PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
