namespace BuildingManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class RegistrationsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Person()
        {
            return this.View();
        }

        public IActionResult Company()
        {
            return this.View();
        }
    }
}
