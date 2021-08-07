namespace BuildingManagementSystem.Services.Data.Registrations.RegisterProperty
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Properties;

    public interface IPropertyService
    {
        Task<int> AddPropertyAsync(int propertyType, int propertyFloor, int number, string propertyPart, string coowner, int dogCount, string userId);

        public IEnumerable<PropertyTypeViewModel> GetPropertyTypes();

        public IEnumerable<PropertyFloorViewModel> GetPropertyFloors();

        public IEnumerable<ShowAllPropertiesViewModel> AllProperties();

        void ConfirmSelectedPropertyRegitration(int propertyId);

        Task<int> AddPropertyLastDataAsync(string coowner, int dogCount, string userId);
    }
}
