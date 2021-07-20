namespace BuildingManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ManagerController : BaseController
    {
        public IActionResult General()
        {
            return this.View();
        }
    }
}
