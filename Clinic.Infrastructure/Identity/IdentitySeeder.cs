using Clinic.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Identity
{

    public static class IdentitySeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {

            var roles = new[]
{
                 "Admin",
                 "Doctor",
                 "Receptionist"
};

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            var adminUser = await userManager.FindByEmailAsync(IdentityConstants.AdminEmail);

            if (adminUser is null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = IdentityConstants.AdminUserName,
                    Email = IdentityConstants.AdminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(
                    adminUser,
                    IdentityConstants.AdminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, IdentityConstants.Admin);
                }
            }

        }
    }

}
