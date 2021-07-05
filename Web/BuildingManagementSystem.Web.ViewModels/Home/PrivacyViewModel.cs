namespace BuildingManagementSystem.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    public class PrivacyViewModel
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string PolicyDescription { get; set; }
    }
}
