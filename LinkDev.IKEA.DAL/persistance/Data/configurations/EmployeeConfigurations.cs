using LinkDev.IKEA.DAL.Entities.common;
using LinkDev.IKEA.DAL.Entities.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.Data.configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasColumnType("varchar(100)");
            builder.Property(E => E.Salary).HasColumnType("decimal(8,2)");
            builder.Property(E => E.Gender).HasConversion(
                (gender) => gender.ToString(),
                (gender)=>(Gender)Enum.Parse(typeof(Gender),gender)
                );
            builder.Property(E => E.EmployeeType).HasConversion(
             (emp) => emp.ToString(),
             (emp) => (EmployeeType)Enum.Parse(typeof(EmployeeType), emp)
             );

            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GetDate()");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GetDate()");


        }
    }
}
