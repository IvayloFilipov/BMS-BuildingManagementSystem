namespace BuildingManagementSystem.Web.ViewModels.ManagerModules
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class AddIncomeViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете наименование на прихода")]
        [Display(Name = "Наименование на прихода")]
        public string PaymentDescription { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете изберете начина на плащне")]
        [Display(Name = "Начин на плащане")]
        public int PaymentTypeId { get; set; }

        public IEnumerable<PaymentTypeDataModel> Payments { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете сумата на прихода")]
        [Display(Name = "Сума на прихода")]
        public decimal Amount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете описание на периода на прихода")]
        [Display(Name = "Описание на периода за който се отнася прихода")]
        public string PaymentPeriod { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете задълженият обект/имот")]
        [Display(Name = "Задължен обект/имот")]
        public int PropertyId { get; set; }

        public IEnumerable<PropertyDataModel> Properties { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете имената на платеца")]
        [Display(Name = "Име и фамилия на платеца")]
        public string PayerName { get; set; }

        // public int AccountId { get; set; }
        // public IEnumerable<BuildingAccountsViewModel> Accounts { get; set; }
    }
}
