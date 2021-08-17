namespace BuildingManagementSystem.Services.Data.Registrations.RegisterProperty
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Properties;
    using Microsoft.EntityFrameworkCore;

    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext dbContext;

        public PropertyService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ShowAllPropertiesViewModel> AllProperties()
        {
            var property = this.dbContext
                .Properties
                .Where(x => x.IsSold == false)
                .Select(x => new ShowAllPropertiesViewModel
                {
                    Id = x.Id,
                    BuildingName = x.Building.Name,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number.ToString(),
                    PropertyPart = x.PropertyPart,
                })
                .ToList();

            return property;
        }

        public async Task<ShowAllPropertiesViewModel> SelectedProperty(int propertyId)
        {
            var property = await this.dbContext
                .Properties
                .Select(x => new ShowAllPropertiesViewModel
                {
                    Id = x.Id,
                    BuildingName = x.Building.Name,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number.ToString(),
                    PropertyPart = x.PropertyPart,
                    IsSold = x.IsSold,
                })
                .FirstOrDefaultAsync(x => x.IsSold && x.Id == propertyId);

            return property;
        }

        public void ConfirmSelectedPropertyRegitration(int propertyId)
        {
            var currProperty = this.dbContext
                .Properties
                .Where(x => x.Id == propertyId && x.IsSold == false)
                .FirstOrDefault();

            if (currProperty == null)
            {
                return;
            }

            currProperty.IsSold = true;

            this.dbContext.SaveChanges();
        }

        public async Task<int> AddPropertyLastDataAsync(string coOwner, int dogCount, string userId, int propertyId)
        {
            var property = await this.dbContext.Properties.FindAsync(propertyId);

            if (property is null)
            {
                throw new System.ArgumentException($"Invalid property ID={propertyId}!", nameof(propertyId));
            }

            property.CoOwner = coOwner;
            property.DogCount = dogCount;
            property.UserId = userId;

            await this.dbContext.SaveChangesAsync();

            return property.Id;
        }
    }
}
