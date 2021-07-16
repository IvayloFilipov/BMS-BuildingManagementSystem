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
            var floors = new List<string> { "Подземни гаражи", "Партер", "1", "2", "3", "4", "5" };

            foreach (var currFloor in floors)
            {
                if (!dbContext.PropertyFloors.Any(x => x.Floor == currFloor))
                {
                    dbContext.PropertyFloors.Add(
                        new PropertyFloor()
                        {
                            Floor = currFloor,
                        });
                }

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
