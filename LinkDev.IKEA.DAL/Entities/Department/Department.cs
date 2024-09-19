using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Entities.Department
{
    internal class Department:ModelBase
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Code { get; set; }
        DateTime CreationDate { get; set; }

    }
}
