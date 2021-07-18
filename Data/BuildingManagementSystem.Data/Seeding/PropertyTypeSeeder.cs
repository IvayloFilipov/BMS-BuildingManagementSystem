namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;

    using static BuildingManagementSystem.Common.GlobalConstants;

    internal class PropertyTypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var types = new List<string>
            {
                ShopPropertyType,
                AppartmentPropertyType,
                StudioPropertyType,
            };

            foreach (var currType in types)
            {
                if (!dbContext.PropertyTypes.Any(x => x.Type == currType))
                {
                    await dbContext.PropertyTypes.AddAsync(
                        new PropertyType()
                        {
                            Type = currType,
                        });
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
