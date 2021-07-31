namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var seeders = new List<ISeeder>
                          {
                              new BuildingAccountsSeeder(),
                              new BuildingNameSeeder(),
                              new BuildingAddressSeeder(),
                              new CitiySeeder(),
                              new ExpenseTypeSeeder(),
                              new MonthlyFeesSeeder(),
                              new PaymentTypeSeeder(),
                              new PropertyFloorSeeder(),
                              new PropertyStatusSeeder(),
                              new PropertyTypeSeeder(),
                              new RolesSeeder(),
                              new UsersSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }

            //var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            //await CreateAdmin(userManager, AdminUserName, AdminFirstName, AdminLastName, AdminEmail, AdminPhomeNumber, DefaultAdminPassword, AdministratorRoleName);

            //await CreateOwner(userManager, OwnerUserName, OwnerFirstName, OwnerLastName, OwnerEmail, OwnerPhomeNumber, DefaultOwnerPassword, OwnerRoleName);

            //await CreateTenant(userManager, TenantUserName, TenantFirstName, TenantLastName, TenantEmail, TenantPhomeNumber, DefaultTenantPassword, TenantRoleName);
        }

        //private static async Task CreateAdmin(UserManager<ApplicationUser> userManager, string username, string firstName, string lastName, string email, string phone, string defaultPassword, string role)
        //{
        //    var adminUser = await userManager.FindByEmailAsync(email);

        //    if (adminUser == null)
        //    {
        //        adminUser = new ApplicationUser()
        //        {
        //            UserName = username,
        //            FirstName = firstName,
        //            LastName = lastName,
        //            Email = email,
        //            PhoneNumber = phone,
        //            EmailConfirmed = true,
        //        };

        //        var result = await userManager.CreateAsync(adminUser, defaultPassword);

        //        await userManager.AddToRoleAsync(adminUser, role);
        //    }
        //}

        //private static async Task CreateOwner(UserManager<ApplicationUser> userManager, string username, string firstName, string lastName, string email, string phone, string defaultPassword, string role)
        //{
        //    var ownerUser = await userManager.FindByEmailAsync(email);

        //    if (ownerUser == null)
        //    {
        //        ownerUser = new ApplicationUser()
        //        {
        //            UserName = username,
        //            FirstName = firstName,
        //            LastName = lastName,
        //            Email = email,
        //            PhoneNumber = phone,
        //            EmailConfirmed = true,
        //        };

        //        var result = await userManager.CreateAsync(ownerUser, defaultPassword);

        //        await userManager.AddToRoleAsync(ownerUser, role);
        //    }
        //}

        //private static async Task CreateTenant(UserManager<ApplicationUser> userManager, string username, string firstName, string lastName, string email, string phone, string defaultPassword, string role)
        //{
        //    var tenantUser = await userManager.FindByEmailAsync(email);

        //    if (tenantUser == null)
        //    {
        //        tenantUser = new ApplicationUser()
        //        {
        //            UserName = username,
        //            FirstName = firstName,
        //            LastName = lastName,
        //            Email = email,
        //            PhoneNumber = phone,
        //            EmailConfirmed = true,
        //        };

        //        var result = await userManager.CreateAsync(tenantUser, defaultPassword);

        //        await userManager.AddToRoleAsync(tenantUser, role);
        //    }
        //}
    }
}
