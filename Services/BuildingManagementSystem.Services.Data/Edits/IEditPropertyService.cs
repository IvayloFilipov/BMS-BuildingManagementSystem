namespace BuildingManagementSystem.Services.Data.Edits
{
    using System.Collections.Generic;

    using BuildingManagementSystem.Web.ViewModels.Properties;

    public interface IEditPropertyService
    {
        public IEnumerable<EditPropertyFormModel> AllProperties();

        void Edit(int id, string buildingName, string coowner, int dogCount, int tenantId, int owner, int companyOwner, string userId, bool isSold, int statusId);
    }
}
