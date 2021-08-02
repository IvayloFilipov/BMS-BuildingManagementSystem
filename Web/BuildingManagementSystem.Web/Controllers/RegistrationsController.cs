namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterAddress;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterCompanyOwner;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterOwner;
    using BuildingManagementSystem.Web.Infrastructure;
    using BuildingManagementSystem.Web.ViewModels.Registrations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RegistrationsController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOwnerService ownerService;
        private readonly ICompanyOwnerService companyOwnerService;
        private readonly IAddressService addressService;
        private readonly IInitialRegisterService initialRegister;

        public RegistrationsController(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            IOwnerService ownerService,
            ICompanyOwnerService companyOwnerService,
            IAddressService addressService,
            IInitialRegisterService initialRegister)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
            this.ownerService = ownerService;
            this.companyOwnerService = companyOwnerService;
            this.addressService = addressService;
            this.initialRegister = initialRegister;
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
        public async Task<IActionResult> RegisterPerson(RegisterPersonViewModel person)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(person);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var userId = user.Id;

            var userIdFromMethod = this.User.GetId();

            await this.ownerService.AddOwnerAsync(person.FirstName, person.MiddleName, person.LastName, person.Email, person.Phone, person.UserId);

            return this.RedirectToAction(nameof(this.RegisterAddress));
        }

        public IActionResult RegisterCompany()
        {
            return this.View();
        }

        // [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> RegisterCompany(RegisterCompanyViewModel company)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(company);
            }

            await this.companyOwnerService.AddCompanyOwnerAsync(company.CompanyName, company.UIC, company.CompanyOwnerFirstName, company.CompanyOwnerLastName, company.Email, company.Phone);

            return this.RedirectToAction(nameof(this.RegisterAddress));
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
        public async Task<IActionResult> RegisterAddress(RegisterAddressViewModel address)
        {
            if (!this.ModelState.IsValid)
            {
                address.AllCities = this.GetAllCities();

                return this.View(address);
            }

            await this.addressService.AddAddressAsync(address.CityId, address.District, address.ZipCode, address.Street, address.StreetNumber, address.BlockNumber, address.EntranceNumber, address.Floor, address.AppartNumber);

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

        // [Authorize(Roles = "Admin")]
        public IActionResult ShowAllUsers()
        {
            var allUsers = this.initialRegister.GetAllUsers();

            var newModelShowUsers = new ShowAllUsersViewModel()
            {
                RegisteredUsers = allUsers
                .Where(x => x.IsRegisterConfirmed == false),
            };

            return this.View(newModelShowUsers);
        }

        // Тук нямам вю, направо трябва да сетна роля на юзъра и да направя IsRegisterConfirmed -> true
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SetRoleToUser(ShowAllUsersViewModel allUsers)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(allUsers);
            }

            //var userId = this.userManager.FindByIdAsync();

            //var roleId = this.userManager.GetUsersInRoleAsync();

            //await initialRegister.SetRoleAsync();

            return this.RedirectToAction(nameof(this.Index), "Registrations");
        }

        // Set isDeleted to true
        // [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser()
        {
            return this.View();
        }
    }
}
