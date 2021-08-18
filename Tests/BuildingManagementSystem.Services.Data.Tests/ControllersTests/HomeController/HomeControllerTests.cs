namespace BuildingManagementSystem.Services.Data.Tests.ControllersTests.HomeController
{
    using BuildingManagementSystem.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void IndexShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IActionResult>(result);

            // Assert.IsType<Task<IActionResult>>(result); <- example
            // Assert.IsType<RedirectToActionResult>(result); <- example
        }

        [Fact]
        public void InfoShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Info();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void PrivacyShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Privacy();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void FaqShouldReturnView()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Faq();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
