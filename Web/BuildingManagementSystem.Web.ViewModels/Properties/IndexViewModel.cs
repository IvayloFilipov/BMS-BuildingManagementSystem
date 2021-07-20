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
        public int PtropertyFloor { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете номера на апартамента/магазина")]
        [Range(1, 15, ErrorMessage = "Въведеният {0} трябва да е между {1} и {2}.")]
        [Display(Name = "Номер на апартамента/магазина")]
        public int AppartNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете % идеални части")]
        [Display(Name = "% идеални части (запишете до третият знак след десетичната запетая)")]
        public double PropertyPart { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Моля въведете броя на кучетата (ако имате такива)")]
        [Range(0, 5, ErrorMessage = "Въведеният {0} трябва да е между {1} и {2}.")]
        [Display(Name = "Брой на притежаваните домашни любимци (кучета)")]
        public int? DogCount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля отбележете съсобственост")]
        [Display(Name = "Съсобственост (отбележете само ако сте в съсобственост)")]
        public bool HasSecondOwner { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля отбележете за наемател/и (ако имате такива)")]
        [Display(Name = "Наемател (отбележете само ако имате наемател/и)")]
        public bool HasTenant { get; set; }
    }
}
