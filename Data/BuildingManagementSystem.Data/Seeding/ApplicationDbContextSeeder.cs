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
                              new RolesSeeder(),
                              new UsersSeeder(),
                              new CitiySeeder(),
                              new BuildingAddressSeeder(),
                              new ExpenseTypeSeeder(),
                              new MonthlyFeesSeeder(),
                              new PaymentTypeSeeder(),
                              new PropertyFloorSeeder(),
                              new PropertyStatusSeeder(),
                              new PropertyTypeSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
