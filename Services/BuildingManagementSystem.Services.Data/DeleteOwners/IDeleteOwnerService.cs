namespace BuildingManagementSystem.Services.Data.DeleteOwners
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.ManagerModules.DeleteOwners;

    public interface IDeleteOwnerService
    {
        public Task<IEnumerable<GetOwnersViewModel>> GetAllOwners();

        Task RemoveOwner(int propertyId);
    }
}
