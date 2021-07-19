namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;

    internal class BuildingNameSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var buildingName = "Моята Кооперация";

            var building = new Building
            {
                Name = buildingName,
            };

            await dbContext.Building.AddAsync(building);

            await dbContext.SaveChangesAsync();
        }
    }
}
