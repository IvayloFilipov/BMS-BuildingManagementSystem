namespace BuildingManagementSystem.Services.Data.Tests.ServicesTests.Rgistrations
{
    using System;
    using System.Linq;
    using BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using Xunit;

    public class InitialRegisterServiceTests
    {
        [Fact]
        public void GetAllUsersAsyncShouldGetAllRegisteredUsers()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;
            var initialRegisterService = new InitialRegisterService(dbContext);

            // data.Users.Add(new BuildingManagementSystem.Data.Models.ApplicationUser());
            dbContext.Users.AddRange(Enumerable.Range(1, 3).Select(x => new BuildingManagementSystem.Data.Models.ApplicationUser() { FirstName = "Ivan" }));

            dbContext.SaveChanges();

            // Act
            var result = initialRegisterService.GetAllUsersAsync().GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void SetRoleAsyncSetSelectedRoleToTheSelectedUserAndSetIsRegisteredConfirmToTrue()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString("D");
            var roleId = Guid.NewGuid().ToString("D");

            using var dbContext = DataBaseMock.Instance;
            var initialRegisterService = new InitialRegisterService(dbContext);

            var user = new BuildingManagementSystem.Data.Models.ApplicationUser() { Id = userId, IsRegisterConfirmed = false };
            dbContext.Users.Add(user);

            dbContext.Roles.Add(new BuildingManagementSystem.Data.Models.ApplicationRole() { Id = roleId });

            // dbContext.UserRoles.Add(new Microsoft.AspNetCore.Identity.IdentityUserRole<string>() { UserId = userId, RoleId = roleId });

            dbContext.SaveChanges();

            // Act
            var result = initialRegisterService.IsRegisterConfirmAsync(userId, roleId).GetAwaiter().GetResult();

            // Assert
            Assert.NotNull(result);
            Assert.True(user.IsRegisterConfirmed);
        }

        [Fact]
        public void RemoveUserShouldSetIsDeletedToTrue()
        {
            // Arrange
            string userId = Guid.NewGuid().ToString("D");

            using var dbContext = DataBaseMock.Instance;
            var initialRegisterService = new InitialRegisterService(dbContext);

            var user = new BuildingManagementSystem.Data.Models.ApplicationUser() { Id = userId, IsDeleted = false };
            dbContext.Users.Add(user);

            dbContext.SaveChanges();

            // Act
            initialRegisterService.RemoveUserAsync(userId).GetAwaiter().GetResult();

            // Assert
            Assert.True(user.IsDeleted);
        }
    }
}
