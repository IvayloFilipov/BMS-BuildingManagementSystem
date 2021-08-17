namespace BuildingManagementSystem.Services.Data.Edits
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Properties;
    using Microsoft.EntityFrameworkCore;

    public class EditPropertyService : IEditPropertyService
    {
        private readonly ApplicationDbContext dbContext;

        public EditPropertyService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<EditPropertyFormModel> AllProperties()
        {
            var property = this.dbContext
                .Properties
                .Select(x => new EditPropertyFormModel
                {
                    Id = x.Id,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number.ToString(),
                    IsSold = x.IsSold ? "Да" : "Не",
                    UserId = $"{x.User.FirstName} {x.User.LastName}",
                    CoOwner = x.CoOwner,
                    DogCount = x.DogCount,
                    StatusId = x.Status.Status,
                })
                .ToList();

            return property;
        }

        public async Task EditAsync(int propertyId, string coowner, int dogCount, int status)
        {
            var selectedProperty = this.dbContext
                .Properties
                .Find(propertyId);

            if (selectedProperty == null)
            {
                throw new System.ArgumentException($"Invalid property ID={propertyId}!", nameof(propertyId));
            }

            selectedProperty.CoOwner = coowner;
            selectedProperty.DogCount = dogCount;
            selectedProperty.StatusId = status;

            await this.dbContext.SaveChangesAsync();
        }

        public IEnumerable<PropertyStatusDataModel> GetPropertyStatus()
        {
            var status = this.dbContext
                .PropertyStatusMonthly
                .Select(s => new PropertyStatusDataModel
                {
                    Id = s.Id,
                    PropertyStatus = s.Status,
                })
                .ToList();

            return status;
        }

        public async Task<EditPropertyViewModel> SelectedPropertyAsync(int propertyId)
        {
            var property = await this.dbContext
                .Properties
                .Select(x => new EditPropertyViewModel
                {
                    Id = x.Id,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number.ToString(),
                    CoOwner = x.CoOwner,
                    DogCount = x.DogCount,
                    StatusId = x.StatusId,
                })
                .FirstOrDefaultAsync(x => x.Id == propertyId);

            return property;
        }
    }
}
