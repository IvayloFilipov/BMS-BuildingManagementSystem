namespace BuildingManagementSystem.Web.ViewModels.Properties
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EditPropertyViewModel
    {
        public int Id { get; set; }

        public string PropertyType { get; set; }

        public string PropertyFloor { get; set; }

        public string PropertyNumber { get; set; }

        [StringLength(100, ErrorMessage = "Въведените данни не могат да бъдат по-малко от {1} и повече от {2} символа.", MinimumLength = 3)]
        [Display(Name = "Съсобственик")]
        public string CoOwner { get; set; }

        [Range(0, 5, ErrorMessage = "Въведеният {0} трябва да е между {1} и {2}.")]
        [Display(Name = "Брой на притежаваните домашни любимци (кучета)")]
        public int DogCount { get; set; }

        public int StatusId { get; set; }

        [Display(Name = "Статус (изберете новият статус на имота)")]
        public IEnumerable<PropertyStatusDataModel> Statuses { get; set; }
    }
}
