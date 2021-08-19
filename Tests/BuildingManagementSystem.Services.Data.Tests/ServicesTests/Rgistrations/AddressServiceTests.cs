namespace BuildingManagementSystem.Services.Data.Tests.ServicesTests.Rgistrations
{
    using System;
    using System.Linq;

    using BuildingManagementSystem.Services.Data.Registrations.RegisterAddress;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using Xunit;

    public class AddressServiceTests
    {
        [Fact]
        public void AddAddressAsyncShouldAddAddressIntoTheDB()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var addressService = new AddressService(dbContext);

            var cityId = 1;
            var district = "Център";
            var street = "ул. София";
            var streetNumber = "2а";
            var blockNumber = "1";
            var entranceNumber = "2а";
            var floor = "Партер";
            var appartNumber = "2";
            var userId = Guid.NewGuid().ToString("D");

            // Act
            var result = addressService.AddAddressAsync(cityId, district, street, streetNumber, blockNumber, entranceNumber, floor, appartNumber, userId).GetAwaiter().GetResult();

            var resultSecond = addressService.AddAddressAsync(cityId, district, street, streetNumber, blockNumber, entranceNumber, floor, appartNumber, userId).GetAwaiter().GetResult();

            var address = dbContext.Addresses.FirstOrDefault();

            // Assert
            Assert.NotNull(address);
            Assert.Equal(district, address.District);

            Assert.Equal(2, dbContext.Addresses.Count());
        }
    }
}
