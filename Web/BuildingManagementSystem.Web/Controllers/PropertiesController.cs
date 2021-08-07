namespace BuildingManagementSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterProperty;
    using BuildingManagementSystem.Web.ViewModels.Properties;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PropertiesController : BaseController
    {
        private readonly IPropertyService propertyService;
        private readonly UserManager<ApplicationUser> userManager;

        public PropertiesController(IPropertyService propertyService, UserManager<ApplicationUser> userManager)
        {
            this.propertyService = propertyService;
            this.userManager = userManager;
        }

        // [Authorize(Roles = "Owner")]
        public IActionResult Index()
        {
            return this.View(new IndexViewModel
            {
                Types = this.propertyService.GetPropertyTypes(),
                Floors = this.propertyService.GetPropertyFloors(),
            });
        }

        // [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> Index(IndexViewModel property)
        {
            if (!this.ModelState.IsValid)
            {
                property.Types = this.propertyService.GetPropertyTypes();
                property.Floors = this.propertyService.GetPropertyFloors();

                return this.View(property);
            }

            // var userId = this.User.GetId();
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = user.Id;

            await this.propertyService.AddPropertyAsync(property.PropertyTypeId, property.PtropertyFloorId, property.AppartNumber, property.PropertyPart, property.CoOwner, property.DogCount, userId);

            return this.RedirectToAction(nameof(ModulesController.Index), "Home");
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult ShowAllProperties()
        {
            var allProperties = this.propertyService.AllProperties();

            return this.View(allProperties);
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult ConfirmPropertyRegitration(ShowAllPropertiesViewModel property)
        {
            var propertyId = property.Id;

            if (propertyId == 0)
            {
                return this.BadRequest();
            }

            this.propertyService.ConfirmSelectedPropertyRegitration(propertyId);

            return this.RedirectToAction(nameof(PropertiesController.ShowSelectedProperties), "Properties");
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult ShowSelectedProperties()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowSelectedProperties(FinalRegistrationPropertyViewModel data)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(data);
            }

            // var userId = this.User.GetId();
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = user.Id;

            var lastData = await this.propertyService.AddPropertyLastDataAsync(data.CoOwner, data.DogCount, userId);

            return this.RedirectToAction(nameof(HomeController.Info), "Home");
        }
    }
}
