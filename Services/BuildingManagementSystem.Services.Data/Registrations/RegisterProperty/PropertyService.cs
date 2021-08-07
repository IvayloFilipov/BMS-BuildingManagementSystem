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

        public async Task<int> AddPropertyAsync(int propertyTypeId, int propertyFloorId, int number, string propertyPart, string coowner, int dogCount, string userId)
        {
            var selectedBuildingId = this.dbContext
                .Building
                .Select(x => x.Id)
                .FirstOrDefault();

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
                BuildingId = selectedBuildingId,
                PropertyTypeId = selectedPropertyTypeId,
                PropertyFloorId = selectedPropertyFloorId,
                Number = number,
                PropertyPart = propertyPart,
                CoOwner = coowner,
                DogCount = dogCount,
                UserId = userId,
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

        public IEnumerable<ShowAllPropertiesViewModel> AllProperties()
        {
            var property = this.dbContext
                .Properties
                .Where(x => x.IsSold == false)
                .Select(x => new ShowAllPropertiesViewModel
                {
                    Id = x.Id,
                    BuildingName = x.Building.Name,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number.ToString(),
                    PropertyPart = x.PropertyPart,
                })
                .ToList();

            return property;
        }

        public void ConfirmSelectedPropertyRegitration(int propertyId)
        {
            var currProperty = this.dbContext
                .Properties
                .Where(x => x.Id == propertyId && x.IsSold == false)
                .FirstOrDefault();

            if (currProperty == null)
            {
                return;
            }

            currProperty.IsSold = true;

            this.dbContext.SaveChanges();
        }

        public async Task<int> AddPropertyLastDataAsync(string coowner, int dogCount, string userId)
        {
            var property = new Property()
            {
                CoOwner = coowner,
                DogCount = dogCount,
                UserId = userId,
            };

            await this.dbContext.Properties.AddAsync(property);

            await this.dbContext.SaveChangesAsync();

            return property.Id;
        }
    }
}
