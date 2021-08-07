namespace BuildingManagementSystem.Web.ViewModels.Properties
{
    using System.ComponentModel.DataAnnotations;

    public class FinalRegistrationPropertyViewModel : ShowAllPropertiesViewModel
    {
        [Required(AllowEmptyStrings = true, ErrorMessage = "Моля въведете броя на кучетата (ако имате такива)")]
        [Range(0, 5, ErrorMessage = "Въведеният {0} трябва да е между {1} и {2}.")]
        [Display(Name = "Брой на притежаваните домашни любимци (кучета)")]
        public int DogCount { get; set; }

        [StringLength(100, ErrorMessage = "Въведените данни не могат да бъдат по-малко от {1} и повече от {2} символа.", MinimumLength = 8)]
        [Display(Name = "Име и фамилия на съсобственика (отбележете само ако сте в съсобственост)")]
        public string CoOwner { get; set; }

        [Required]
        public string LoggedUserId { get; set; }
    }
}
