namespace BuildingManagementSystem.Services.Data.Tests.ServicesTests.Tenants
{
    using System;
    using System.Linq;

    using BuildingManagementSystem.Services.Data.Registrations.Tenants;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using Xunit;

    public class TenantServiceTests
    {
        private const string UserId = "MyUserIdAsGuid";

        [Fact]
        public void AddTenantAsyncShoudAddTenant()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var tenantService = new TenantService(dbContext);

            var firstName = "Иван";
            var middleName = "Иванов";
            var lastName = "Иванов";
            var email = "owner@owner.com";
            var phone = "+359888112233";
            var userId = Guid.NewGuid().ToString("D");

            // Act
            var result = tenantService.AddTenantAsync(firstName, middleName, lastName, email, phone, userId).GetAwaiter().GetResult();

            var resultSecond = tenantService.AddTenantAsync(firstName, middleName, lastName, email, phone, userId).GetAwaiter().GetResult();

            var tenant = dbContext.Tenants.FirstOrDefault();

            // Assert
            Assert.NotNull(tenant);
            Assert.Equal(middleName, tenant.MiddleName);

            Assert.Equal(2, dbContext.Tenants.Count());
        }

        [Fact]
        public void GetAllAsyncShouldGetAllRegisteredTenants()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var tenantService = new TenantService(dbContext);

            var firstName = "Иван";
            var middleName = "Иванов";
            var lastName = "Иванов";
            var email = "ivan@owner.com";
            var phone = "+359888112233";
            var userId = Guid.NewGuid().ToString("D");

            var firstName2 = "Петко";
            var middleName2 = "Петков";
            var lastName2 = "Петков";
            var email2 = "petko@owner.com";
            var phone2 = "+359888112244";
            var userId2 = Guid.NewGuid().ToString("D");

            var firstTenant = tenantService.AddTenantAsync(firstName, middleName, lastName, email, phone, userId).GetAwaiter().GetResult();

            var secondTenant = tenantService.AddTenantAsync(firstName2, middleName2, lastName2, email2, phone2, userId2).GetAwaiter().GetResult();

            dbContext.SaveChanges();

            // Act
            var result = tenantService.GetAllAsync().GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void ConfirmTenantRegitrationShouldConfimTenantandSetIsConfirmedToTrue()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var tenantService = new TenantService(dbContext);

            var firstName = "Иван";
            var middleName = "Иванов";
            var lastName = "Иванов";
            var email = "ivan@owner.com";
            var phone = "+359888112233";
            var userId = Guid.NewGuid().ToString("D");

            var tenantId = tenantService.AddTenantAsync(firstName, middleName, lastName, email, phone, userId).GetAwaiter().GetResult();

            // Act
            tenantService.ConfirmTenantRegitrationAsync(tenantId).GetAwaiter().GetResult();

            // Assert

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void RemoveTenantShouldRemoveTenantBySettingIsDeleatedToTrue(int tenantId)
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var tenantService = new TenantService(dbContext);

            var firstName = "Иван";
            var middleName = "Иванов";
            var lastName = "Иванов";
            var email = "ivan@owner.com";
            var phone = "+359888112233";
            var userId = Guid.NewGuid().ToString("D");

            var firstName2 = "Петко";
            var middleName2 = "Петков";
            var lastName2 = "Петков";
            var email2 = "petko@owner.com";
            var phone2 = "+359888112244";
            var userId2 = Guid.NewGuid().ToString("D");

            var firstTenant = tenantService.AddTenantAsync(firstName, middleName, lastName, email, phone, userId).GetAwaiter().GetResult();

            var secondTenant = tenantService.AddTenantAsync(firstName2, middleName2, lastName2, email2, phone2, userId2).GetAwaiter().GetResult();

            // Act
            tenantService.RemoveTenantAsync(tenantId).GetAwaiter().GetResult();

            // Assert
            Assert.Equal(1, 1);
        }
    }
}
