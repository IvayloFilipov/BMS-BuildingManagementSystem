namespace BuildingManagementSystem.Web.Controllers
{
    using BuildingManagementSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DocumentsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;

        public DocumentsController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult UploadDocument()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult UploadDocument(int id, string name, string extension, string description)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.RedirectToAction(nameof(HomeController.Index), "Home"); // change path
        }
    }
}
