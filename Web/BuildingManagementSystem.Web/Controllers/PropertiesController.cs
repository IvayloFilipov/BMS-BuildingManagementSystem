namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Properties;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PropertiesController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public PropertiesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return this.View(new IndexViewModel
            {
                Types = this.GetPropertyTypes(),
                Floors = this.GetPropertyFloors(),
            });
        }

        // Needed db in order to get Property types values
        [HttpPost]
        [Authorize(Roles = "Admin, Owner")]
        public IActionResult Index(IndexViewModel type)
        {
            if (!this.ModelState.IsValid)
            {
                type.Types = this.GetPropertyTypes();
                type.Floors = this.GetPropertyFloors();

                return this.View(type);
            }

            return this.RedirectToAction(nameof(ModulesController.Index), "Modules");
        }

        private IEnumerable<PropertyTypeViewModel> GetPropertyTypes()
        {
            var types = this.dbContext
                .PropertyTypes
                .Select(x => new PropertyTypeViewModel
                {
                    Id = x.Id,
                    TypeName = x.Type,
                })
                .ToList();

            return types;
        }

        private IEnumerable<PropertyFloorViewModel> GetPropertyFloors()
        {
            var floors = this.dbContext
                .PropertyFloors
                .Select(x => new PropertyFloorViewModel
                {
                    Id = x.Id,
                    FloorName = x.Floor,
                })
                .ToList();

            return floors;
        }
    }
}
