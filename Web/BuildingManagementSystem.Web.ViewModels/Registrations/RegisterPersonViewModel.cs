namespace BuildingManagementSystem.Web.ViewModels.Registrations
{
    using System.ComponentModel.DataAnnotations;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class RegisterPersonViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете Вашето името")]
        [StringLength(OwnerFirstNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = 3)]
        [Display(Name = "Вашето име")]
        public string FirstName { get; set; }

        [StringLength(OwnerMiddleNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = 5)]
        [Display(Name = "Вашето презиме")]
        public string MiddleName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете Вашата фамилия")]
        [StringLength(OwnerLastNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = 4)]
        [Display(Name = "Вашата фамилия")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият email адрес")]
        [EmailAddress(ErrorMessage = "Моля въведете валиден email адрес")]
        [Display(Name = "Вашият е-мейл адрес")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият телефонен номер")]
        [Phone]
        [RegularExpression(@"^[+]{1}[3][5][9][0-9]{9}$", ErrorMessage = PhoneNumberErrorMessage)]
        [Display(Name = "Мобилен телефонен номер")]
        public string Phone { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
