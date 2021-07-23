namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;
    using Microsoft.EntityFrameworkCore;

    internal class CitiySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            // The predefine cities
            var cities = new List<string>
            {
                "София",
                "Пловдив",
                "Варна",
                "Бургас",
                "Шумен",
                "Каспичан",
                "с. Осмар",
                "с. Мадара",
                "с. Васил Друмев",
            };

            // Get all City entities from db.
            var dbCities = await dbContext.Cities.Select(c => c.Name).ToListAsync();

            // Get only cities that do not exists in db.
            var newCities = cities.Where(currCity => !dbCities.Contains(currCity))
                .Select(currCity => new City { Name = currCity }) // Create a City entity
                .ToList();

            if (!newCities.Any())
            {
                return;
            }

            await dbContext.Cities.AddRangeAsync(newCities);

            await dbContext.SaveChangesAsync();
        }
    }
}
