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

        public IEnumerable<GetOwnersViewModel> GetAllOwners()
        {
            var propertiesOwners = this.dbContext
                .Properties
                .Select(x => new GetOwnersViewModel
                {
                    Id = x.Id,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number.ToString(),
                    OwnerNames = $"{x.User.FirstName} {x.User.LastName}",
                    CompanyName = this.dbContext
                        .CompanyOwners
                        .Where(co => co.UserId == x.UserId)
                        .Select(co => co.CompanyName)
                        .FirstOrDefault() ?? "N/A",
                })
                .ToList();

            return propertiesOwners;
        }

        public void RemoveOwner(string userId/*, string roleId*/)
        {
            // Remove record from AspNetUserRoles
            // 1-st variant
            //var aspUser = this.dbContext.UserRoles.Find(userId);

            //if (aspUser == null)
            //{
            //    return;
            //}

            //this.dbContext.UserRoles.Remove(aspUser);

            // 2-nd variant
            var aspnetUser = this.dbContext.UserRoles.Single(u => u.UserId == userId);

            foreach (var role in aspnetUser.RoleId.ToList())
            {
                aspnetUser.RoleId.Remove(role);
            }

            this.dbContext.UserRoles.Remove(aspnetUser);

            // 3-rd variant
            // this.dbContext.Users.Find(userId).Roles.Remove(this.dbContext.UserRoles.Find(roleId));

            // Set AspNetUser IsDeleted to true and IsRegisteredConfim to false
            var aspUser1 = this.dbContext.Users.Find(userId);

            if (aspUser1 != null)
            {
                aspUser1.IsDeleted = true;
                aspUser1.IsRegisterConfirmed = false;
            }

            // Remove User's records from Properies
            var property = this.dbContext.Properties.Find(userId);

            if (property != null)
            {
                property.CoOwner = null;
                property.DogCount = 0;
                property.UserId = null;
                property.IsSold = false;
            }

            // Set Owner/CompanyOwner IsDeleted to true
            var owner = this.dbContext.Owners.Find(userId);

            var companyOwner = this.dbContext.CompanyOwners.Find(userId);

            if (owner != null)
            {
                owner.IsDeleted = true;
            }
            else
            {
                companyOwner.IsDeleted = true;
            }

            // Set IsDeleted in Addresses to true
            var addressUser = this.dbContext.Addresses.Find(userId);

            if (addressUser != null)
            {
                addressUser.IsDeleted = true;
            }

            // save changes
            this.dbContext.SaveChanges();
        }
    }
}
