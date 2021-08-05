namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;

    internal class BuildingAddressSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var cityId = dbContext.Cities.Where(c => c.Name == "София").Select(c => c.Id).FirstOrDefault();

            var buildingId = dbContext.Building.Where(c => c.Name == "Моята Кооперация").Select(b => b.Id).FirstOrDefault();

            var buildingAddress = new Address()
            {
                CityId = cityId,
                District = "Сердика",
                ZipCode = 1202,
                Street = "Княз Борис I",
                StreetNumber = "196",
                BuildingId = buildingId,
            };

            if (dbContext.Addresses.Any())
            {
                return;
            }

            await dbContext.Addresses.AddAsync(buildingAddress);

            await dbContext.SaveChangesAsync();
        }
    }
}
