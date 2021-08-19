namespace BuildingManagementSystem.Services.Data.Tests.ServicesTests.DeleteOwners
{
    using BuildingManagementSystem.Services.Data.DeleteOwners;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using Xunit;

    public class DeleteOwnersTests
    {
        [Fact]
        public void GetAllOwnersShouldReturnAllRegiteredOwners()
        {
        }

        [Fact]
        public void RemoveOwnerShouldDeleteSelectedOwner()
        {
            // Arrange
            var dbContext = DataBaseMock.Instance;
            var deleteOwnerService = new DeleteOwnerService(dbContext);

            var propertyId = 1;
            var userId = System.Guid.NewGuid().ToString("D");

            dbContext.Owners.Add(new BuildingManagementSystem.Data.Models.BuildingData.Owner() { UserId = userId });

            var property = new BuildingManagementSystem.Data.Models.BuildingData.Property() { Id = propertyId, UserId = userId, IsSold = true, DogCount = 2 };
            dbContext.Properties.Add(property);

            dbContext.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>() { UserId = userId, RoleId = System.Guid.NewGuid().ToString("D") });

            dbContext.Users.Add(new BuildingManagementSystem.Data.Models.ApplicationUser() { Id = userId });

            dbContext.SaveChanges();

            // Act
            deleteOwnerService.RemoveOwner(propertyId).GetAwaiter().GetResult();

            // Assert
            Assert.Equal(0, property.DogCount);
            Assert.False(property.IsSold);
            Assert.Null(property.UserId);
        }
    }
}
