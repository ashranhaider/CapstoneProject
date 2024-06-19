using CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace CapstoneProject.Data
{
    public class DataSeeder
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public DataSeeder(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            // Create roles if they don't exist
            var adminRoleExists = await _roleManager.RoleExistsAsync("Admin");
            var employeeRoleExists = await _roleManager.RoleExistsAsync("Employee");

            if (!adminRoleExists)
            {
                await _roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            if (!employeeRoleExists)
            {
                await _roleManager.CreateAsync(new AppRole { Name = "Employee" });
            }

            // Create users with roles if they don't exist
            var adminUser = await _userManager.FindByNameAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@example.com",
                    FirstName = "Admin",
                    LastName = "User"
                };

                await _userManager.CreateAsync(adminUser, "Abcd123?"); // Replace with a secure password
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }

            var employeeUser = await _userManager.FindByNameAsync("employee@example.com");
            if (employeeUser == null)
            {
                employeeUser = new AppUser
                {
                    UserName = "employee@employee.com",
                    Email = "employee@example.com",
                    FirstName = "Employee",
                    LastName = "User"
                };

                await _userManager.CreateAsync(employeeUser, "Abcd123?"); // Replace with a secure password
                await _userManager.AddToRoleAsync(employeeUser, "Employee");
            }
        }
    }

}
