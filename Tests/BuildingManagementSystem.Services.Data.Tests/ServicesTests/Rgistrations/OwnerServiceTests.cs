namespace BuildingManagementSystem.Services.Data.Tests.ServicesTests.Rgistrations
{
    using System;
    using System.Linq;

    using BuildingManagementSystem.Services.Data.Registrations.RegisterOwner;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using Xunit;

    public class OwnerServiceTests
    {
        [Fact]
        public void AddOwnerAsyncShouldAddTheOwner()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var ownerService = new OwnerService(dbContext);

            var firstName = "Иван";
            var middleName = "Иванов";
            var lastName = "Иванов";
            var email = "owner@owner.com";
            var phone = "+359888112233";
            var userId = Guid.NewGuid().ToString("D");

            // Act
            var result = ownerService.AddOwnerAsync(firstName, middleName, lastName, email, phone, userId).GetAwaiter().GetResult();

            var resultSecond = ownerService.AddOwnerAsync(firstName, middleName, lastName, email, phone, userId).GetAwaiter().GetResult();

            dbContext.SaveChanges();

            var owner = dbContext.Owners.FirstOrDefault();

            // Assert
            Assert.NotNull(owner);
            Assert.Equal(middleName, owner.MiddleName);

            Assert.Equal(2, dbContext.Owners.Count());
        }
    }
}
