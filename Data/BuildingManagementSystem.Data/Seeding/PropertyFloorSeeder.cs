namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;

    internal class PropertyFloorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var floors = new List<string>
            {
                "Партер",
                "1",
                "2",
                "3",
                "4",
                "5",
            };

            var newFloorsList = new List<PropertyFloor>();

            foreach (var currFloor in floors)
            {
                if (!dbContext.PropertyFloors.Any(x => x.Floor == currFloor))
                {
                    var newFloor = new PropertyFloor()
                    {
                        Floor = currFloor,
                    };

                    newFloorsList.Add(newFloor);
                }
            }

            if (!newFloorsList.Any())
            {
                return;
            }

            await dbContext.AddRangeAsync(newFloorsList);

            await dbContext.SaveChangesAsync();
        }
    }
}
