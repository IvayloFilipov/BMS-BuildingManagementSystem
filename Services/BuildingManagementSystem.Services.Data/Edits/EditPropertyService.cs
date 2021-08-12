namespace BuildingManagementSystem.Services.Data.Edits
{
    using System.Collections.Generic;
    using System.Linq;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Properties;

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

        public void Edit(int id, string buildingName, string coowner, int dogCount, int tenantId, int owner, int companyOwner, string userId, bool isSold, int statusId)
        {
            throw new System.NotImplementedException();
        }
    }
}
