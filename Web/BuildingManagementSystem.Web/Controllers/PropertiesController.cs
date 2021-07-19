namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Properties;
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
            });
        }

        // Needed db in order to get Property types values
        [HttpPost]
        public IActionResult Index(IndexViewModel type)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(type);
            }

            return this.RedirectToAction("Index", "Modules");
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
    }
}
