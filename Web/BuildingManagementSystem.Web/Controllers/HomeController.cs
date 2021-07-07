namespace BuildingManagementSystem.Web.Controllers
{
    using System.Diagnostics;

    using BuildingManagementSystem.Web.ViewModels;
    using BuildingManagementSystem.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            var privacy = new PrivacyViewModel
            {
                Title = "Политика на поверителност и общи условия за ползване на Приложението",
                PolicyDescription = "Съгласни ли сте...",
            };

            return this.View(privacy);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
