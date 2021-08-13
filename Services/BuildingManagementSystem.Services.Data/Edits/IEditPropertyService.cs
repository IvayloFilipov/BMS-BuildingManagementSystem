namespace BuildingManagementSystem.Services.Data.Edits
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Properties;

    public interface IEditPropertyService
    {
        public IEnumerable<EditPropertyFormModel> AllProperties();

        Task EditAsync(int propertyId, string coowner, int dogCount, int status/*, string userId, bool isSold*/);

        public IEnumerable<PropertyStatusDataModel> GetPropertyStatus();

        Task<EditPropertyViewModel> SelectedPropertyAsync(int propertyId);
    }
}
