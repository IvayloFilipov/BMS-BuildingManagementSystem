namespace BuildingManagementSystem.Web.ViewModels.Tenants.ManagerModules
{
    using System.Collections.Generic;

    public class TenantsViewModel
    {
        // public int TenantsId { get; set; }
        public IEnumerable<AllTenantsDataModel> Tenants { get; set; }
    }
}
