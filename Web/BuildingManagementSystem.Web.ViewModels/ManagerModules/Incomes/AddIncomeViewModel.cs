namespace BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.ManagerModules.Incomes;

    public class AddIncomeViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете наименование на прихода")]
        [StringLength(50, ErrorMessage = "Полето '{0}' трябва да съдържа минимум {2} и максимум {1} символа.", MinimumLength = 5)]
        [Display(Name = "Наименование на прихода")]
        public string IncomeDescription { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете изберете начина на плащне")]
        [Display(Name = "Начин на плащане")]
        public int PaymentTypeId { get; set; }

        public IEnumerable<PaymentTypeDataModel> Payments { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете сумата на прихода")]
        [Display(Name = "Сума на прихода")]
        public decimal Amount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете описание на периода на прихода")]
        [StringLength(150, ErrorMessage = "Полето '{0}' трябва да съдържа минимум {2} и максимум {1} символа.", MinimumLength = 5)]
        [Display(Name = "Описание на периода за който се отнася прихода")]
        public string PaymentPeriod { get; set; }

        // [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете типа на имота на задълженият  обект")]
        // [Display(Name = "Задължен обект/тип на имота")]
        // public int PropertyId { get; set; }
        // public IEnumerable<PropertyTypeDataModel> Properties { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете етажа на задълженият обект")]
        [Display(Name = "Задължен обект/етаж")]
        public int PropertyFloorId { get; set; }

        public IEnumerable<PropertyFloorDataModel> Floors { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете номера задълженият обект")]
        [Range(1, 15, ErrorMessage = "Номерата в полето '{0}' трябва да са между {1} и {2}.")]
        [Display(Name = "Задължен обект/номер")]
        public int PropertyNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете имената на платеца")]
        [StringLength(50, ErrorMessage = "олето '{0}' трябва да съдържа минимум {2} и максимум {1} символа.", MinimumLength = 8)]
        [Display(Name = "Име и фамилия на платеца")]
        public string PayerName { get; set; }

        [Display(Name = "Задължен обект")]
        public int PropertiesId { get; set; }

        public IEnumerable<PropertiesSomePartsDataModel> Properties { get; set; }

        // public IEnumerable<Property> Properties { get; set; }
    }
}
