namespace BuildingManagementSystem.Services.Data.Tests.Mock
{
    using BuildingManagementSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Moq;

    public static class UserManagerMock
    {
        // public static Mock<UserManager<IdentityUser>> New
        //   => new Mock<UserManager<IdentityUser>>(
        //     Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);

        public static UserManager<ApplicationUser> Instance
        {
            get
            {
                var mockedUser = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<IdentityUser>>(), null, null, null, null, null, null, null, null);

                return mockedUser.Object;
            }
        }
    }
}
