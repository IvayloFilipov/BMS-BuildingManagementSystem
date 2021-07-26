namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Registrations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class RegistrationsController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public RegistrationsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult RegisterPerson()
        {
            return this.View();
        }

        // [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult RegisterPerson(RegisterPersonViewModel person)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(person);
            }

            return this.RedirectToAction("RegisterAddress");
        }

        public IActionResult RegisterCompany()
        {
            return this.View();
        }

        // [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult RegisterCompany(RegisterCompanyViewModel company)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(company);
            }

            return this.RedirectToAction("RegisterAddress");
        }

        public IActionResult RegisterAddress()
        {
            return this.View(new RegisterAddressViewModel
            {
                AllCities = this.GetAllCities(),
            });
        }

        // [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult RegisterAddress(RegisterAddressViewModel address)
        {
            if (!this.ModelState.IsValid)
            {
                address.AllCities = this.GetAllCities();

                return this.View(address);
            }

            return this.RedirectToAction(nameof(PropertiesController.Index), "Properties");
        }

        public IEnumerable<AllCitiesDataModel> GetAllCities()
        {
            var cities = this.dbContext
                .Cities
                .Select(x => new AllCitiesDataModel
                {
                    Id = x.Id,
                    City = x.Name,
                })
                .ToList();

            return cities;
        }
    }
}
