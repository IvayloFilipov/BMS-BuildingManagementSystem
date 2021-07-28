namespace BuildingManagementSystem.Services.Data.Registrations.RegisterProperty
{
    using System.Threading.Tasks;

    public interface IPropertyService
    {
        Task<int> AddPropertyAsync(int propertyType, int propertyFloor, int number, double propertyPart, string coowner, int dogCount);
    }
}
