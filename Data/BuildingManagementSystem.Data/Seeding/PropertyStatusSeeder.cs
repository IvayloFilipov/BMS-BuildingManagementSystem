namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.Debts;

    using static BuildingManagementSystem.Common.GlobalConstants;

    internal class PropertyStatusSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var statuses = new List<string>()
            {
                CommertialPropertyStatus,
                TemporariliFreePropertyStatus,
                UnoccupiedPropertyStatus,
                OccupiedPropertyStatus,
            };

            var newStatusesList = new List<PropertyStatus>();

            foreach (var currStatus in statuses)
            {
                if (!dbContext.PropertyStatusMonthly.Any(x => x.Status == currStatus))
                {
                    var newStatus = new PropertyStatus()
                    {
                        Status = currStatus,
                    };

                    newStatusesList.Add(newStatus);
                }
            }

            if (!newStatusesList.Any())
            {
                return;
            }

            await dbContext.PropertyStatusMonthly.AddRangeAsync(newStatusesList);

            await dbContext.SaveChangesAsync();
        }
    }
}
