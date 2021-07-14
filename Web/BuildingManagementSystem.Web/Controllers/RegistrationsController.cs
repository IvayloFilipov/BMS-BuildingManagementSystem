namespace BuildingManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class RegistrationsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult RegisterPerson()
        {
            return this.View();
        }

        public IActionResult RegisterCompany()
        {
            return this.View();
        }

        public IActionResult RegisterAddress()
        {
            return this.View();
        }

        public IActionResult RegisterTenant()
        {
            return this.View();
        }
    }
}
