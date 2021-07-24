namespace BuildingManagementSystem.Web.Controllers
{
    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Services.Data.Registrations.RegisterTenant;
    using BuildingManagementSystem.Web.ViewModels.Tenants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class TenantsController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IRegisterTenantService registerTenant;

        public TenantsController(ApplicationDbContext dbContext, IRegisterTenantService registerTenant)
        {
            this.dbContext = dbContext;
            this.registerTenant = registerTenant;
        }

        public IActionResult RegisterTenant()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
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
