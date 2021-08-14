namespace BuildingManagementSystem.Services.Data.DeleteOwners
{
    using System.Collections.Generic;
    using System.Linq;
    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.ManagerModules.DeleteOwners;

    public class DeleteOwnerService : IDeleteOwnerService
    {
        private readonly ApplicationDbContext dbContext;

        public DeleteOwnerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DeleteOwnerViewModel> GetAllOwners()
        {
            var tenants = this.dbContext
                .Properties
                .Select(x => new DeleteOwnerViewModel
                {
                    Id = x.Id,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number.ToString(),
                    UserId = $"{x.User.FirstName} {x.User.LastName}",
                    CompanyName = this.dbContext
                        .CompanyOwners
                        .Where(co => co.UserId == x.UserId)
                        .Select(co => co.CompanyName)
                        .FirstOrDefault() ?? "N/A",
                })
                .ToList();

            return tenants;
        }

        public void RemoveOwner(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
