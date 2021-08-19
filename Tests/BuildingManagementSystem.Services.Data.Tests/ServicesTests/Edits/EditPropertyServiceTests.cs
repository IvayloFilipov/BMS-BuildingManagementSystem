namespace BuildingManagementSystem.Services.Data.Tests.ServicesTests.Edits
{
    using BuildingManagementSystem.Services.Data.Edits;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using Xunit;

    public class EditPropertyServiceTests
    {
        [Fact]
        public void EditAsyncShouldSetNewDataIntoSelectedProperty()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var editPropertyService = new EditPropertyService(dbContext);

            var propertyId = 1;
            var coowner = "Ivanka";
            var dogCount = 2;
            var statusId = 1;

            var property = dbContext.Properties.Add(new BuildingManagementSystem.Data.Models.BuildingData.Property() { Id = propertyId, CoOwner = coowner, DogCount = dogCount, StatusId = statusId });

            var newPropertyId = 1;
            var newCoOwner = "Petko";
            var newDogCount = 1;
            var newStatusId = 2;

            // Act
            editPropertyService.EditAsync(newPropertyId, newCoOwner, newDogCount, newStatusId).GetAwaiter().GetResult();

            // Assert
            Assert.Equal(newPropertyId, property.Entity.Id);
            Assert.Equal(newCoOwner, property.Entity.CoOwner);
            Assert.Equal(newDogCount, property.Entity.DogCount);
            Assert.Equal(newStatusId, property.Entity.StatusId);
        }
    }
}
