using Microsoft.AspNetCore.Identity;
using Plagiarism_Checker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker
{
    public class DataInitializer
    {
        public static void SeedData(UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Student").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Student";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Teacher").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Teacher";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                User user = new User();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Admin007").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,"Admin").Wait();
                }
            }
        }
    }
}
