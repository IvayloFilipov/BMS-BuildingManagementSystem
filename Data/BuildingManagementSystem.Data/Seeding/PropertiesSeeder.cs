namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;

    public class PropertiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Properties.Any())
            {
                return;
            }

            var buildingId = dbContext.Building.Where(c => c.Name == "Моята Кооперация").Select(b => b.Id).FirstOrDefault();

            var shopType = dbContext.PropertyTypes.Where(x => x.Type == "Магазин").Select(x => x.Id).FirstOrDefault();
            var appartmentType = dbContext.PropertyTypes.Where(x => x.Type == "Апартамент").Select(x => x.Id).FirstOrDefault();
            var studioType = dbContext.PropertyTypes.Where(x => x.Type == "Студио").Select(x => x.Id).FirstOrDefault();

            var parterFloor = dbContext.PropertyFloors.Where(x => x.Floor == "Партер").Select(x => x.Id).FirstOrDefault();
            var firstFloor = dbContext.PropertyFloors.Where(x => x.Floor == "1").Select(x => x.Id).FirstOrDefault();
            var secondFloor = dbContext.PropertyFloors.Where(x => x.Floor == "2").Select(x => x.Id).FirstOrDefault();
            var thirdFloor = dbContext.PropertyFloors.Where(x => x.Floor == "3").Select(x => x.Id).FirstOrDefault();

            var properties = new List<(
                int BuildingId,
                int PropertyTypeId,
                int PropertyFloorId,
                int PropertyNumber,
                string PropertyParts)>
            {
                (buildingId, shopType, parterFloor, 1, "1,111"),
                (buildingId, shopType, parterFloor, 2, "2,222"),
                (buildingId, shopType, parterFloor, 3, "3,333"),
                (buildingId, appartmentType, firstFloor, 1, "1,111"),
                (buildingId, appartmentType, firstFloor, 2, "2,222"),
                (buildingId, appartmentType, firstFloor, 3, "3,333"),
                (buildingId, appartmentType, secondFloor, 4, "1,111"),
                (buildingId, appartmentType, secondFloor, 5, "2,222"),
                (buildingId, appartmentType, secondFloor, 6, "3,333"),
                (buildingId, studioType, thirdFloor, 7, "1,111"),
                (buildingId, studioType, thirdFloor, 8, "2,222"),
                (buildingId, studioType, thirdFloor, 9, "3,333"),
            };

            foreach (var currProp in properties)
            {
                await dbContext.Properties.AddAsync(new Property
                {
                    BuildingId = currProp.BuildingId,
                    PropertyTypeId = currProp.PropertyTypeId,
                    PropertyFloorId = currProp.PropertyFloorId,
                    Number = currProp.PropertyNumber,
                    PropertyPart = currProp.PropertyParts,
                });
            }
        }
    }
}
