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
        private readonly ITenantService tenantService;

        public TenantsController(UserManager<ApplicationUser> userManager, ITenantService tenantService)
        {
            this.userManager = userManager; // TenantsController needed UserManager.
            this.tenantService = tenantService;
        }

        // [Authorize(Roles = "User, Admin")]
        public IActionResult RegisterTenant()
        {
            return this.View();
        }

        // [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterTenantAsync(RegisterTenantViewModel tenant)
        {
            // Must set in -> RegisterTenantViewModel : MapTo<Tenant> <-
            // var currTenant = AutoMapperConfig.MapperInstance.Map<Tenant>(tenant);
            // var userId = this.User.GetId();
            if (!this.ModelState.IsValid)
            {
                return this.View(tenant);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.userManager.AddToRoleAsync(user, TenantRoleName);

            // await this.tenantService.RegisterTenantAsync(tenant, userId);
            await this.tenantService.RegisterTenantAsync(tenant, user.Id);

            return this.RedirectToAction(nameof(HomeController.Info), "Home");
        }
    }
}
