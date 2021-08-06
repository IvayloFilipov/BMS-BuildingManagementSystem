namespace BuildingManagementSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterProperty;
    using BuildingManagementSystem.Web.Infrastructure;
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

        public IActionResult Index()
        {
            return this.View(new IndexViewModel
            {
                Types = this.propertyService.GetPropertyTypes(),
                Floors = this.propertyService.GetPropertyFloors(),
            });
        }

        // Needed db in order to get Property types values
        // [Authorize(Roles = "Admin, Owner")]
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

            return this.RedirectToAction(nameof(ModulesController.Index), "Modules");
        }

        //private IEnumerable<PropertyTypeViewModel> GetPropertyTypes()
        //{
        //    var types = this.dbContext
        //        .PropertyTypes
        //        .Select(x => new PropertyTypeViewModel
        //        {
        //            Id = x.Id,
        //            TypeName = x.Type,
        //        })
        //        .ToList();

        //    return types;
        //}

        //private IEnumerable<PropertyFloorViewModel> GetPropertyFloors()
        //{
        //    var floors = this.dbContext
        //        .PropertyFloors
        //        .Select(x => new PropertyFloorViewModel
        //        {
        //            Id = x.Id,
        //            FloorName = x.Floor,
        //        })
        //        .ToList();

        //    return floors;
        //}
    }
}
