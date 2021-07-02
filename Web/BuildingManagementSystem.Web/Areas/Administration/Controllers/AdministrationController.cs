namespace BuildingManagementSystem.Web.Areas.Administration.Controllers
{
    using BuildingManagementSystem.Common;
    using BuildingManagementSystem.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
