namespace BuildingManagementSystem.Services.Data.DeleteOwners
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.ManagerModules.DeleteOwners;
    using Microsoft.EntityFrameworkCore;

    public class DeleteOwnerService : IDeleteOwnerService
    {
        private readonly ApplicationDbContext dbContext;

        public DeleteOwnerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<GetOwnersViewModel>> GetAllOwners()
        {
            var propertiesOwners = await this.dbContext
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
                .ToListAsync();

            return propertiesOwners;
        }

        public async Task RemoveOwner(int propertyId/*, string roleId*/)
        {
            // Remove record from AspNetUserRoles
            var selectedProperty = await this.dbContext.Properties.FirstOrDefaultAsync(p => p.Id == propertyId);
            var userId = selectedProperty.UserId;

            var aspNetUser = await this.dbContext.UserRoles.SingleAsync(u => u.UserId == userId);

            this.dbContext.UserRoles.Remove(aspNetUser);

            // Set AspNetUser IsDeleted to true and IsRegisteredConfim to false
            var aspUser = await this.dbContext.Users.FindAsync(userId);

            if (aspUser != null)
            {
                aspUser.IsDeleted = true;
                aspUser.IsRegisterConfirmed = false;
            }

            // Remove User's records from Properies
            var property = await this.dbContext.Properties.FindAsync(propertyId);

            if (property != null)
            {
                property.CoOwner = null;
                property.DogCount = 0;
                property.UserId = null;
                property.IsSold = false;
            }

            // Set Owner/CompanyOwner IsDeleted to true
            var owner = await this.dbContext.Owners.FirstOrDefaultAsync(x => x.UserId == userId);

            if (owner != null)
            {
                owner.IsDeleted = true;
            }
            else
            {
                var companyOwner = await this.dbContext.CompanyOwners.FirstOrDefaultAsync(x => x.UserId == userId);
                companyOwner.IsDeleted = true;
            }

            // Set IsDeleted in Addresses to true
            var addressUser = await this.dbContext.Addresses.FirstOrDefaultAsync(x => x.UserId == userId);

            if (addressUser != null)
            {
                addressUser.IsDeleted = true;
            }

            await this.dbContext.SaveChangesAsync();
        }
    }
}
