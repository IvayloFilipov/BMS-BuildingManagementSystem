﻿namespace BuildingManagementSystem.Web.Controllers
{
    using BuildingManagementSystem.Web.ViewModels.Registrations;
    using Microsoft.AspNetCore.Mvc;

    public class RegistrationsController : BaseController
    {
        public RegistrationsController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult RegisterPerson()
        {
            return this.View();
        }

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

        [HttpPost]
        public IActionResult RegisterCompany(RegisterCompanyViewModel companyModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(companyModel);
            }

            return this.RedirectToAction("RegisterAddress");
        }

        public IActionResult RegisterAddress()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult RegisterAddress(RegisterAddressViewModel address)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(address);
            }

            return this.RedirectToAction("Index", "Properties");
        }

        public IActionResult RegisterTenant()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult RegisterTenant(RegisterTenantViewModel tenant)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(tenant);
            }

            return this.RedirectToAction("Info", "Home");
        }
    }
}
