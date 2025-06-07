using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.UI.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "ganeshmankar";
        private const string adminPassword = "Secret123$";
        private const string adminEmail = "admin@zensar.com";
        private const string adminPhone = "9822139921";
        private const string adminRole = "Admin";

        private const string adminUser1 = "atharvagaikwad";
        private const string adminPassword1 = "Secret123$";
        private const string adminEmail1 = "admin@zensar.com";
        private const string adminPhone1 = "9822139921";
        private const string adminRole1 = "Admin";

        private const string receptionistUser = "atharva";
        private const string receptionistPassword = "Secret1234$";
        private const string receptionistEmail = "receptionist@zensar.com";
        private const string receptionistPhone = "123456789";
        private const string receptionistRole = "Receptionist";


        public static async Task SeedDataAsync(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Ensure roles exist
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }
            if (!await roleManager.RoleExistsAsync(receptionistRole))
            {
                await roleManager.CreateAsync(new IdentityRole(receptionistRole));
            }

            // Ensure admin user exists
            var userAdmin = await userManager.FindByNameAsync(adminUser);
            if (userAdmin == null)
            {
                userAdmin = new IdentityUser(adminUser)
                {
                    Email = adminEmail,
                    PhoneNumber = adminPhone
                };
                var result = await userManager.CreateAsync(userAdmin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userAdmin, adminRole);
                }
            }

            // Ensure receptionist user exists
            var recepUser = await userManager.FindByNameAsync(receptionistUser);
            if (recepUser == null)
            {
                recepUser = new IdentityUser(receptionistUser)
                {
                    Email = receptionistEmail,
                    PhoneNumber = receptionistPhone
                };
                var result = await userManager.CreateAsync(recepUser, receptionistPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(recepUser, receptionistRole);
                }
            }
        }
    }
}
