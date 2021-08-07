namespace BuildingManagementSystem.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Services.Data.Registrations.InitialRegistrations;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterAddress;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterCompanyOwner;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterOwner;
    using BuildingManagementSystem.Web.Infrastructure;
    using BuildingManagementSystem.Web.ViewModels.Registrations;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RegistrationsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IOwnerService ownerService;
        private readonly ICompanyOwnerService companyOwnerService;
        private readonly IAddressService addressService;
        private readonly IInitialRegisterService initialRegister;

        public RegistrationsController(
            UserManager<ApplicationUser> userManager,
            IOwnerService ownerService,
            ICompanyOwnerService companyOwnerService,
            IAddressService addressService,
            IInitialRegisterService initialRegister)
        {
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

            await this.ownerService.AddOwnerAsync(person.FirstName, person.MiddleName, person.LastName, person.Email, person.Phone, userId);

            return this.RedirectToAction(nameof(this.RegisterAddress));
        }

        // [Authorize(Roles = "Owner")]
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

            // var userId = this.User.GetId();
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = user.Id;

            await this.companyOwnerService.AddCompanyOwnerAsync(company.CompanyName, company.UIC, company.CompanyOwnerFirstName, company.CompanyOwnerLastName, company.Email, company.Phone, userId);

            return this.RedirectToAction(nameof(this.RegisterAddress));
        }

        public IActionResult RegisterAddress()
        {
            return this.View(new RegisterAddressViewModel
            {
                AllCities = this.addressService.GetAllCities(),
            });
        }

        // [Authorize(Roles = "Owner")]
        [HttpPost]
        public async Task<IActionResult> RegisterAddress(RegisterAddressViewModel address)
        {
            if (!this.ModelState.IsValid)
            {
                address.AllCities = this.addressService.GetAllCities();

                return this.View(address);
            }

            // var userId = this.User.GetId();
            var user = await this.userManager.GetUserAsync(this.User);
            var userId = user.Id;

            await this.addressService.AddAddressAsync(address.CityId, address.District, address.Street, address.StreetNumber, address.BlockNumber, address.EntranceNumber, address.Floor, address.AppartNumber, userId);

            // return this.RedirectToAction(nameof(PropertiesController.Index), "Properties");
            return this.RedirectToAction(nameof(PropertiesController.ShowAllProperties), "Properties");
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

        [HttpPost]
        public async Task<IActionResult> SetRoleToUser(string userId, BuildingManagementSystem.Data.Models.Enums.IdentityRole roleId)
        {
            if (roleId == Data.Models.Enums.IdentityRole.Admin)
            {
                return this.BadRequest();
            }

            var selectedUser = await this.userManager.FindByIdAsync(userId);

            if (selectedUser is null)
            {
                return this.BadRequest();
            }

            if (selectedUser.IsRegisterConfirmed)
            {
                return this.BadRequest();
            }

            selectedUser.IsRegisterConfirmed = true;

            await this.userManager.UpdateAsync(selectedUser);

            await this.userManager.AddToRoleAsync(selectedUser, roleId.ToString());

            return this.RedirectToAction(nameof(this.Index), "Registrations");
        }

        //// [Authorize(Roles = "Admin")]
        // public async Task<IActionResult> DeleteUser(string id)
        // {
        //     var user = await this.userManager.FindByIdAsync(id);
        //     if (user is null)
        //     {
        //         return this.BadRequest();
        //     }
        //     user.IsDeleted = true;
        //     await this.userManager.UpdateAsync(user);
        //     return this.RedirectToAction(nameof(this.Index), "Registrations");
        // }

        // [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser()
        {
            var userId = this.User.GetId();

            if (userId is null)
            {
                return this.BadRequest(userId);
            }

            this.initialRegister.RemoveUser(userId);

            return this.RedirectToAction(nameof(this.Index), "Registrations");
        }
    }
}
