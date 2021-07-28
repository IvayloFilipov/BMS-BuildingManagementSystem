namespace BuildingManagementSystem.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;

    using BuildingManagementSystem.Services.Data.Registrations.RegisterTenant;
    using BuildingManagementSystem.Web.Infrastructure;
    using BuildingManagementSystem.Web.ViewModels.Tenants;
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
            this.userManager = userManager; // TenantsController needed UserManager.
            this.roleManager = roleManager;
            this.tenantService = tenantService;
        }

        // [Authorize(Roles = "Owner, Admin")]
        // [Authorize]
        public IActionResult RegisterTenant()
        {
            return this.View();
        }

        // [Authorize(Roles = "Owner, Admin")]
        // [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterTenantAsync(RegisterTenantViewModel tenant)
        {
            // Must set in -> RegisterTenantViewModel : MapTo<Tenant> <-
            // var currTenant = AutoMapperConfig.MapperInstance.Map<Tenant>(tenant);

            if (!this.ModelState.IsValid)
            {
                return this.View(tenant);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userId = this.User.GetId();

            var isRoleExist = await this.roleManager.RoleExistsAsync(TenantRoleName);

            if (isRoleExist)
            {
                var result = await this.userManager.AddToRoleAsync(user, TenantRoleName);

                if (!result.Succeeded)
                {
                    this.ModelState.AddModelError(string.Empty, $"Adding role: {TenantRoleName} failed");
                }
                else
                {
                    this.ViewBag.Message = $"Role: {TenantRoleName} was added";

                    return this.View();
                }
            }

            // await this.tenantService.RegisterTenantAsync(tenant, userId);
            await this.tenantService.AddTenantAsync(tenant.FirstName, tenant.MiddleName, tenant.LastName, tenant.Email, tenant.Phone, userId);

            return this.RedirectToAction(nameof(HomeController.Info), "Home");
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
