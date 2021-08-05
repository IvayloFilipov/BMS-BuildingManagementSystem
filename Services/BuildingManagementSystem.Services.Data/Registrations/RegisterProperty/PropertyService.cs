namespace BuildingManagementSystem.Services.Data.Registrations.RegisterProperty
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.Properties;

    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext dbContext;

        public PropertyService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddPropertyAsync(int propertyTypeId, int propertyFloorId, int number, double propertyPart, string coowner, int dogCount)
        {
            var selectedPropertyTypeId = this.dbContext
                .PaymentTypes
                .Where(x => x.Id == propertyTypeId)
                .Select(x => x.Id)
                .FirstOrDefault();

            var selectedPropertyFloorId = this.dbContext
                .PropertyFloors
                .Where(x => x.Id == propertyFloorId)
                .Select(x => x.Id)
                .FirstOrDefault();

            var property = new Property()
            {
                PropertyTypeId = selectedPropertyTypeId,
                PropertyFloorId = selectedPropertyFloorId,
                Number = number,
                PropertyPart = propertyPart,
                CoOwner = coowner,
                DogCount = dogCount,
            };

            await this.dbContext.Properties.AddAsync(property);

            await this.dbContext.SaveChangesAsync();

            return property.Id;
        }

        public IEnumerable<PropertyFloorViewModel> GetPropertyFloors()
        {
            var floors = this.dbContext
                .PropertyFloors
                .Select(x => new PropertyFloorViewModel
                {
                    Id = x.Id,
                    FloorName = x.Floor,
                })
                .ToList();

            return floors;
        }

        public IEnumerable<PropertyTypeViewModel> GetPropertyTypes()
        {
            var types = this.dbContext
                   .PropertyTypes
                   .Select(x => new PropertyTypeViewModel
                   {
                       Id = x.Id,
                       TypeName = x.Type,
                   })
                   .ToList();

            return types;
        }
    }
}
