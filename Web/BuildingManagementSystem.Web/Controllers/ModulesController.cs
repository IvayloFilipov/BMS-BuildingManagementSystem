namespace BuildingManagementSystem.Web.Controllers
{
    using BuildingManagementSystem.Web.ViewModels.Modules;
    using Microsoft.AspNetCore.Mvc;

    public class ModulesController : BaseController
    {
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            return this.View(model);
        }
    }
}
