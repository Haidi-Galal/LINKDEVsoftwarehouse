using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.BLL.Services.Employees;
using LinkDev.IKEA.DAL.Entities.Identity;
using LinkDev.IKEA.DAL.persistance.Data;
using LinkDev.IKEA.DAL.persistance.Repoistories.Departments;
using LinkDev.IKEA.DAL.persistance.Repoistories.Employees;
using LinkDev.IKEA.DAL.persistance.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.IKEA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region register services 
            builder.Services.AddControllersWithViews();
            // builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>
            //    (
            //     (serviceProvider) =>
            //     {
            //         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //         optionsBuilder.UseSqlServer("");
            //        var options= optionsBuilder.Options;
            //         return options;
            //     }
            //    );

                builder.Services.AddDbContext<ApplicationDbContext>
                (
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                );

            builder.Services.AddScoped<IDepartmentRepoistory, DepartmentRepoistory>();
              builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IEmployeeRepoistory, EmployeeRepoistory>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>
                (
                  (options) =>
                  {
                      options.Password.RequiredLength = 5;
                      options.Password.RequireUppercase = true;
                      options.User.RequireUniqueEmail = true;
                      options.Lockout.AllowedForNewUsers = true;
                      options.Lockout.MaxFailedAccessAttempts = 4;
                      options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);

                  }
                ).AddEntityFrameworkStores < ApplicationDbContext>(); //Register Stores (Repos)

            builder.Services.ConfigureApplicationCookie
                (
                (options) =>
                {
                    options.LoginPath = "/Account/SignIn";
                    options.AccessDeniedPath = "/Home/error";
                    options.LogoutPath = "/Account/SignIn";

				}

                );
            #endregion
            var app = builder.Build();
            



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
