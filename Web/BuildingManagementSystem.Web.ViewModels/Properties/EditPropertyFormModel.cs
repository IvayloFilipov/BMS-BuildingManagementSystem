namespace BuildingManagementSystem.Web.ViewModels.Properties
{
    public class EditPropertyFormModel
    {
        public int Id { get; set; }

        public string PropertyType { get; set; }

        public string PropertyFloor { get; set; }

        public string PropertyNumber { get; set; }

        public string IsSold { get; set; }

        // GUID, in view should display owner first and last name
        public string UserId { get; set; }

        public string CoOwner { get; set; }

        public int DogCount { get; set; }

        public string StatusId { get; set; }
    }
}
