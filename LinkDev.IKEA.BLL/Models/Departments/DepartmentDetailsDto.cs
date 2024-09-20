﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.BLL.Models.Departments
{
    internal class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Code { get; set; }
        DateTime CreationDate { get; set; }
    }
}