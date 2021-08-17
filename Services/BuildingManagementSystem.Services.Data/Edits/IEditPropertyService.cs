namespace BuildingManagementSystem.Services.Data.Edits
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Properties;

    public interface IEditPropertyService
    {
        Task<IEnumerable<EditPropertyFormModel>> AllPropertiesAsync();

        Task EditAsync(int propertyId, string coowner, int dogCount, int status);

        Task<IEnumerable<PropertyStatusDataModel>> GetPropertyStatus();

        Task<EditPropertyViewModel> SelectedPropertyAsync(int propertyId);
    }
}
