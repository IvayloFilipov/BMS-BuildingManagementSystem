namespace BuildingManagementSystem.Web.ViewModels.Properties
{
    using System.ComponentModel.DataAnnotations;

    public class PropertyStatusDataModel
    {
        public int Id { get; set; }

        [Display(Name = "Статус (изберете новият статус на имота)")]
        public string PropertyStatus { get; set; }
    }
}
