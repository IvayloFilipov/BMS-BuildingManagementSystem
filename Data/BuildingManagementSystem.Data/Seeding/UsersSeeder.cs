namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using static BuildingManagementSystem.Common.GlobalConstants;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await this.SeedAdmin(userManager);

            await this.SeedOwner(userManager);

            await this.SeedTenant(userManager);
        }

        private async Task SeedAdmin(UserManager<ApplicationUser> userManager)
        {
            var administrators = await userManager.GetUsersInRoleAsync(AdministratorRoleName);

            var admin = administrators.FirstOrDefault();

            if (admin is not null)
            {
                return;
            }

            admin = new ApplicationUser()
            {
                UserName = AdminEmail,
                FirstName = AdminFirstName,
                LastName = AdminLastName,
                Email = AdminEmail,
                PhoneNumber = AdminPhomeNumber,
                EmailConfirmed = true,
                IsRegisterConfirmed = true,
            };

            await userManager.CreateAsync(admin, DefaultAdminPassword);

            await userManager.AddToRoleAsync(admin, AdministratorRoleName);
        }

        private async Task SeedOwner(UserManager<ApplicationUser> userManager)
        {
            var administrators = await userManager.GetUsersInRoleAsync(OwnerRoleName);

            var owner = administrators.FirstOrDefault();

            if (owner is not null)
            {
                return;
            }

            owner = new ApplicationUser()
            {
                UserName = OwnerEmail,
                FirstName = OwnerFirstName,
                LastName = OwnerLastName,
                Email = OwnerEmail,
                PhoneNumber = OwnerPhomeNumber,
                EmailConfirmed = true,
                IsRegisterConfirmed = true,
            };

            await userManager.CreateAsync(owner, DefaultOwnerPassword);

            await userManager.AddToRoleAsync(owner, OwnerRoleName);
        }

        private async Task SeedTenant(UserManager<ApplicationUser> userManager)
        {
            var administrators = await userManager.GetUsersInRoleAsync(TenantRoleName);

            var tenant = administrators.FirstOrDefault();

            if (tenant is not null)
            {
                return;
            }

            tenant = new ApplicationUser()
            {
                UserName = TenantEmail,
                FirstName = TenantFirstName,
                LastName = TenantLastName,
                Email = TenantEmail,
                PhoneNumber = TenantPhomeNumber,
                EmailConfirmed = true,
                IsRegisterConfirmed = true,
            };

            await userManager.CreateAsync(tenant, DefaultTenantPassword);

            await userManager.AddToRoleAsync(tenant, TenantRoleName);
        }
    }
}
