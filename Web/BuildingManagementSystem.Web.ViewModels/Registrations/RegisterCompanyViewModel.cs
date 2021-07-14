namespace BuildingManagementSystem.Web.ViewModels.Registrations
{
    using System.ComponentModel.DataAnnotations;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class RegisterCompanyViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете името на фирмата")]
        [StringLength(CompanyNameMaxLength, ErrorMessage = CompanyNameErrorMessage, MinimumLength = 5)]
        [Display(Name = "Име на фирмата")]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете ЕИК")]
        [MaxLength(9, ErrorMessage = "Полето трябва да съдържа точно {1} цифри")]
        [Display(Name = "Единен идентификационен код (ЕИК)")]
        public string UIC { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете Вашето името")]
        [StringLength(CompanyOwnerFirstNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = 3)]
        [Display(Name = "Вашето име")]
        public string CompanyOwnerFirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете Вашата фамилия")]
        [StringLength(CompanyOwnerLastNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = 4)]
        [Display(Name = "Вашата фамилия")]
        public string CompanyOwnerLastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете Вашият е-мейл")]
        [EmailAddress(ErrorMessage = "Моля въведете валиден email адрес")]
        [StringLength(CompanyEmailMaxLength)]
        [Display(Name = "Е-мейл")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете Вашият телефонен номер")]
        [Phone]
        [StringLength(CompanyPhoneMaxLength)]
        [Display(Name = "Телефонен номер")]
        public string Phone { get; set; }
    }
}
