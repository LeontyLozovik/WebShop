using Identity.Model;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WebShop
{
    public static class IdentityConfiguration
    {
        public static void Init(IServiceProvider serviceProvider)
        {
            string adminName = "admin";
            string adminPassword = "admin";

            var userManager = serviceProvider.GetService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetService<RoleManager<AppRole>>();

            var adminRole = new AppRole("Admin");
            var courierRole = new AppRole("Courier");

            roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            roleManager.CreateAsync(courierRole).GetAwaiter().GetResult();

            var admin = new AppUser { UserName = adminName };
            var result = userManager.CreateAsync(admin, adminPassword).GetAwaiter().GetResult();

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
            }
        }
    }
}
