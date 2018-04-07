using LmycWeb.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmycWeb.DummyData
{
    public class IdentityDummyData
    {
        public static void SeedData(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var passwordHash = new PasswordHasher<ApplicationUser>();

            if (userManager.FindByNameAsync("a").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "a";
                user.Email = "a@a.a";
                user.PasswordHash = passwordHash.HashPassword(user,"P@$$w0rd");

                IdentityResult result = userManager.CreateAsync
                (user).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("b").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "b";
                user.Email = "b@b.b";
                user.PasswordHash = passwordHash.HashPassword(user, "P@$$w0rd");

                IdentityResult result = userManager.CreateAsync
                (user).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Member").Wait();
                }
            }

        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
