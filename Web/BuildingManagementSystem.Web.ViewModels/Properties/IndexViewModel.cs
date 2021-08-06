namespace BuildingManagementSystem.Web.ViewModels.Properties
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class IndexViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете типа на имота")]
        [Display(Name = "Тип на имота")]
        public int PropertyTypeId { get; set; }

        public IEnumerable<PropertyTypeViewModel> Types { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете етажа")]
        [Display(Name = "Етаж")]
        public int PtropertyFloorId { get; set; }

        public IEnumerable<PropertyFloorViewModel> Floors { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете номера на апартамента/магазина")]
        [Range(1, 15, ErrorMessage = "Въведеният '{0}' трябва да е между {1} и {2}.")]
        [Display(Name = "Номер на апартамента/магазина")]
        public int AppartNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете % идеални части")]
        [RegularExpression(@"^[0-9]{1,3},[0-9]{3}$", ErrorMessage = "Въведената стойност трябва да е с точност до третият знак след десетичната запетая")]
        [Display(Name = "% идеални части (запишете до третият знак след десетичната запетая)")]
        public double PropertyPart { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Моля въведете броя на кучетата (ако имате такива)")]
        [Range(0, 5, ErrorMessage = "Въведеният {0} трябва да е между {1} и {2}.")]
        [Display(Name = "Брой на притежаваните домашни любимци (кучета)")]
        public int DogCount { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Моля отбележете съсобственост")]
        [StringLength(100, ErrorMessage = "Въведените данни не могат да бъдат по-малко от {1} и повече от {2} символа.", MinimumLength = 8)]
        [Display(Name = "Име и фамилия на съсобственика (отбележете само ако сте в съсобственост)")]
        public string CoOwner { get; set; }

        [Required]
        public string LoggedUserId { get; set; }
    }
}
