namespace BuildingManagementSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;

    using BuildingManagementSystem.Services.Data.Registrations.Tenants;
    using BuildingManagementSystem.Web.Infrastructure;
    using BuildingManagementSystem.Web.ViewModels.Tenants;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class TenantsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly ITenantService tenantService;

        public TenantsController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ITenantService tenantService)
        {
            this.userManager = userManager; // TenantsController needed UserManager.
            this.roleManager = roleManager;
            this.tenantService = tenantService;
        }

        // [Authorize(Roles = "Owner, Admin")]
        public IActionResult RegisterTenant()
        {
            return this.View();
        }

        // [Authorize(Roles = "Owner, Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterTenantAsync(RegisterTenantViewModel tenant)
        {
            // Must set in -> RegisterTenantViewModel : MapTo<Tenant> <-
            // var currTenant = AutoMapperConfig.MapperInstance.Map<Tenant>(tenant);
            if (!this.ModelState.IsValid)
            {
                return this.View(tenant);
            }

            var ownerId = this.User.GetId();

            await this.tenantService.AddTenantAsync(tenant.FirstName, tenant.MiddleName, tenant.LastName, tenant.Email, tenant.Phone, ownerId);

            return this.RedirectToAction(nameof(HomeController.Info), "Home");
        }

        public IActionResult GetAllTenants()
        {
            var allTenants = this.tenantService.GetAll();

            return this.View(allTenants);
        }

        // [Authorize(Roles = "Owner, Admin")]
        public IActionResult DeleteTenant()
        {
            return this.View();
        }

        // [Authorize(Roles = "Owner, Admin")]
        [HttpPost]
        public IActionResult DeleteTenant(DeleteTenantViewModel tenant)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(tenant);
            }

            return this.RedirectToAction(nameof(HomeController.Info), "Home");
        }
    }
}
