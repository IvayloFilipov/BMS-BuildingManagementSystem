namespace BuildingManagementSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;

    using BuildingManagementSystem.Services.Data.Registrations.Tenants;
    using BuildingManagementSystem.Web.ViewModels.Tenants;
    using BuildingManagementSystem.Web.ViewModels.Tenants.ManagerModules;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class TenantsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly ITenantService tenantService;

        public TenantsController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ITenantService tenantService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tenantService = tenantService;
        }

        [Authorize(Roles = OwnerRoleName)]
        public IActionResult RegisterTenantAsync()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = OwnerRoleName)]
        public async Task<IActionResult> RegisterTenantAsync(RegisterTenantViewModel tenant)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(tenant);
            }

            var loggedUser = await this.userManager.GetUserAsync(this.User);
            var loggedUserId = loggedUser.Id;

            await this.tenantService.AddTenantAsync(tenant.FirstName, tenant.MiddleName, tenant.LastName, tenant.Email, tenant.Phone, loggedUserId);

            return this.RedirectToAction(nameof(HomeController.Info), "Home");
        }

        [Authorize(Roles = AdministratorRoleName)]
        public async Task<IActionResult> GetAllTenants()
        {
            var allTenants = await this.tenantService.GetAllAsync();

            return this.View(allTenants);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult ConfirmRegitration(AllTenantsDataModel tenant)
        {
            var tenantId = tenant.Id;

            if (tenantId == 0)
            {
                return this.BadRequest();
            }

            this.tenantService.ConfirmTenantRegitration(tenantId);

            return this.RedirectToAction(nameof(this.GetAllTenants));
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult DeleteTenant(AllTenantsDataModel tenant)
        {
            var tenantId = tenant.Id;

            if (tenantId == 0)
            {
                return this.BadRequest();
            }

            this.tenantService.RemoveTenant(tenantId);

            return this.RedirectToAction(nameof(this.GetAllTenants));
        }
    }
}
