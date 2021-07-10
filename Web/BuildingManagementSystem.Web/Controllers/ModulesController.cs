namespace BuildingManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ModulesController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
