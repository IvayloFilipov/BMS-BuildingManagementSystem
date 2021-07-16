namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Common;
    using BuildingManagementSystem.Data.Models.BuildingData;

    using static BuildingManagementSystem.Common.GlobalConstants;

    internal class PropertyTypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var types = new List<string> { ShopPropertyType, AppartmentPropertyType, StudioPropertyType, };

            foreach (var currType in types)
            {
                if (!dbContext.PropertyTypes.Any(x => x.Type == currType))
                {
                    dbContext.PropertyTypes.Add(
                        new PropertyType()
                        {
                            Type = currType,
                        });
                }

                await dbContext.SaveChangesAsync();
            }
        }

        // public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        // {
        //     var type = serviceProvider.GetRequiredService<List<PropertyType>>();
        //     await SeedPropertyTypeAsync(type, GlobalConstants.ShopPropertyType);
        //     await SeedPropertyTypeAsync(type, GlobalConstants.AppartmentPropertyType);
        //     await SeedPropertyTypeAsync(type, GlobalConstants.StudioPropertyType);
        // }
        // private static async Task SeedPropertyTypeAsync(List<PropertyType> currType, string propertyType)
        // {
        //     // var type = await currType.FindByNameAsync(propertyType);
        //     var type = await currType.Find(propertyType);
        //     if (type == null)
        //     {
        //         var result = await currType.CreateAsync(new PropertyType(propertyType));
        //         if (!result.Succeeded)
        //         {
        //             throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
        //         }
        //     }
        // }
    }
}
