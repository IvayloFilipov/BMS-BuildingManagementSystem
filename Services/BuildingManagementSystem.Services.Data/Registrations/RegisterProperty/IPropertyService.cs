namespace BuildingManagementSystem.Services.Data.Registrations.RegisterProperty
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Properties;

    public interface IPropertyService
    {
        public IEnumerable<ShowAllPropertiesViewModel> AllProperties();

        void ConfirmSelectedPropertyRegitration(int propertyId);

        Task<int> AddPropertyLastDataAsync(string coowner, int dogCount, string userId, int propertyId);

        Task<ShowAllPropertiesViewModel> SelectedProperty(int propertyId);
    }
}
