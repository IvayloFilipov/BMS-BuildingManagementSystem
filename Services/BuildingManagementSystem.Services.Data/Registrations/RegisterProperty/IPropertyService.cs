namespace BuildingManagementSystem.Services.Data.Registrations.RegisterProperty
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Properties;

    public interface IPropertyService
    {
        Task<IEnumerable<ShowAllPropertiesViewModel>> AllPropertiesAsync();

        void ConfirmSelectedPropertyRegitration(int propertyId);

        Task<int> AddPropertyLastDataAsync(string coowner, int dogCount, string userId, int propertyId);

        Task<ShowAllPropertiesViewModel> SelectedPropertyAsync(int propertyId);
    }
}
