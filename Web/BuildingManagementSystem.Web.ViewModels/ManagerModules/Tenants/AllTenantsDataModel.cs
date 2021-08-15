namespace BuildingManagementSystem.Web.ViewModels.Tenants.ManagerModules
{
    public class AllTenantsDataModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string OwnerId { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
