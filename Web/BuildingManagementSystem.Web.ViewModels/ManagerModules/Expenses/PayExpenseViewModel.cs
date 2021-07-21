namespace BuildingManagementSystem.Web.ViewModels.Expenses.ManagerModules
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;

    public class PayExpenseViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете изберете наименованието на разхода")]
        [Display(Name = "Наименование на разхода")]
        public int ExpenseTypeId { get; set; }

        public IEnumerable<ExpenseTypeDataModel> Expenses { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете изберете начина на плащне")]
        [Display(Name = "Начин на плащане")]
        public int PaymentTypeId { get; set; }

        public IEnumerable<PaymentTypeDataModel> Payments { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете сумата на разхода")]
        [Display(Name = "Сума на разхода")]
        public decimal Amount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете кратко описание на разхода")]
        [StringLength(150, ErrorMessage = "Полето '{0}' трябва да съдържа минимум {2} и максимум {1} символа.", MinimumLength = 5)]
        [Display(Name = "Описание на разхода")]
        public string Description { get; set; }
    }
}
