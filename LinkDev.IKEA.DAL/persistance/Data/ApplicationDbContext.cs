using LinkDev.IKEA.DAL.Entities.Department;
using LinkDev.IKEA.DAL.Entities.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.persistance.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) :base(options)
        {
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-5L3JKJC\\MSSQLSERVER01;Database=MyDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
       public DbSet<Department> Department { get; set; }
       public DbSet<Employee> Employees { get; set; }


    }
}
