namespace BuildingManagementSystem.Services.Data.DeleteOwners
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.ManagerModules.DeleteOwners;

    public interface IDeleteOwnerService
    {
        public IEnumerable<GetOwnersViewModel> GetAllOwners();

        void RemoveOwner(string userId/*, string roleId*/);
    }
}
