namespace BuildingManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PropertiesController : BaseController
    {
        public IActionResult Type()
        {
            return this.View();
        }

        public IActionResult Floor()
        {
            return this.View();
        }

        public IActionResult AddProperty()
        {
            return this.View();
        }
    }
}
