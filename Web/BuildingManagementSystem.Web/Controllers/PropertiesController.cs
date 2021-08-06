﻿namespace BuildingManagementSystem.Web.Controllers
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
    }
}
