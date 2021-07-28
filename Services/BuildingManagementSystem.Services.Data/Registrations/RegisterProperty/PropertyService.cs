namespace BuildingManagementSystem.Services.Data.Registrations.RegisterProperty
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;

    public class PropertyService : IPropertyService
    {
        public Task<int> AddPropertyAsync(int propertyType, int propertyFloor, int number, double propertyPart, string coowner, int dogCount)
        {
            var property = new Property()
            {
                PropertyTypeId = propertyType,
                PropertyFloorId = propertyFloor,
                Number = number,
                PropertyPart = propertyPart,
                CoOwner = coowner,
                DogCount = dogCount,
            };

            return null;
        }
    }
}
