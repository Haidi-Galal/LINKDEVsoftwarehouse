﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Entities.Department
{
    public class Department:ModelBase
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Code { get; set; }
        public  DateTime CreationDate { get; set; }

    }
}
