namespace BuildingManagementSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterProperty;
    using BuildingManagementSystem.Web.ViewModels.Properties;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class PropertiesController : BaseController
    {
        private readonly IPropertyService propertyService;
        private readonly UserManager<ApplicationUser> userManager;

        public PropertiesController(IPropertyService propertyService, UserManager<ApplicationUser> userManager)
        {
            this.propertyService = propertyService;
            this.userManager = userManager;
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult ShowAllProperties()
        {
            var allProperties = this.propertyService.AllProperties();

            return this.View(allProperties);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult ConfirmPropertyRegitration(ShowAllPropertiesViewModel property)
        {
            var propertyId = property.Id;

            if (propertyId == 0)
            {
                return this.BadRequest();
            }

            this.propertyService.ConfirmSelectedPropertyRegitration(propertyId);

            return this.RedirectToAction(nameof(PropertiesController.ShowSelectedProperties), "Properties", new { id = propertyId });
        }

        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> ShowSelectedProperties(int id)
        {
            var selectedProperty = await this.propertyService.SelectedProperty(id);

            var finalModel = new FinalRegistrationPropertyViewModel
            {
                Id = id,
                BuildingName = selectedProperty.BuildingName,
                PropertyType = selectedProperty.PropertyType,
                PropertyFloor = selectedProperty.PropertyFloor,
                PropertyNumber = selectedProperty.PropertyNumber,
                PropertyPart = selectedProperty.PropertyPart,
            };

            return this.View(finalModel);
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> ShowSelectedProperties(FinalRegistrationPropertyViewModel data)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(data);
            }

            // var userId = this.User.GetId();
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = user.Id;

            await this.propertyService.AddPropertyLastDataAsync(data.CoOwner, data.DogCount, userId, data.Id);

            return this.RedirectToAction(nameof(HomeController.Info), "Home");
        }
    }
}
