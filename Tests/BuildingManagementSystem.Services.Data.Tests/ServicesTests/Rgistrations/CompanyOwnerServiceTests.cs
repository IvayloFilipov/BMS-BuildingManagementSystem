namespace BuildingManagementSystem.Services.Data.Tests.ServicesTests.Rgistrations
{
    using System;
    using System.Linq;

    using BuildingManagementSystem.Services.Data.Registrations.RegisterCompanyOwner;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using Xunit;

    public class CompanyOwnerServiceTests
    {
        [Fact]
        public void AddCompanyOwnerAsyncShouldAddTheCompanyOwner()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var companyOwnerService = new CompanyOwnerService(dbContext);

            var companyName = "Тест ООД";
            var uic = "111222333";
            var companyOwnerFirstName = "Иван";
            var companyOwnerLastName = "Иванов";
            var email = "owner@owner.com";
            var phone = "+359888112233";
            var userId = Guid.NewGuid().ToString("D");

            // Act
            var result = companyOwnerService.AddCompanyOwnerAsync(companyName, uic, companyOwnerFirstName, companyOwnerLastName, email, phone, userId).GetAwaiter().GetResult();

            var resultSecond = companyOwnerService.AddCompanyOwnerAsync(companyName, uic, companyOwnerFirstName, companyOwnerLastName, email, phone, userId).GetAwaiter().GetResult();

            dbContext.SaveChanges();

            var owner = dbContext.CompanyOwners.FirstOrDefault();

            // Assert
            Assert.NotNull(owner);
            Assert.Equal(companyOwnerFirstName, owner.CompanyOwnerFirstName);

            Assert.Equal(2, dbContext.CompanyOwners.Count());
        }
    }
}
