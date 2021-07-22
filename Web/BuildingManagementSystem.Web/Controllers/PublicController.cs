namespace BuildingManagementSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PublicController : BaseController
    {
        public PublicController()
        {
        }

        public IActionResult General()
        {
            return this.View();
        }
    }
}
