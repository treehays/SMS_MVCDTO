using Microsoft.AspNetCore.Identity;
using SMS_MVCDTO.Enums;
using SMS_MVCDTO.Models.Entities;
using System.Data;

namespace SMS_MVCDTO.Context
{
    public static class ContextSeed
    {
        public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(UserRoleType.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoleType.SalesManager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoleType.Attendant.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoleType.Customer.ToString()));
        }

        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            /*var defaultUser = new User
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                FirstName = "Ahmad",
                LastName = "Abdulsalam",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };*/
            /*
                        if (userManager.Users.All(u => u.Id != defaultUser.Id))
                        {*/
            /*     var user = await userManager.FindByEmailAsync(defaultUser.Email);
                 if (user == null)
                 {*/
            //await userManager.CreateAsync(defaultUser, "Pass123.");
            /*     await userManager.AddToRoleAsync(User, UserRoleType.SuperAdmin.ToString());
                 await userManager.AddToRoleAsync(Roles.Moderator.ToString());
                 await userManager.AddToRoleAsync(Roles.Admin.ToString());
                 await userManager.AddToRoleAsync(Roles.SuperAdmin.ToString());*/
            //}

            /*  }*/
        }
    }
}

