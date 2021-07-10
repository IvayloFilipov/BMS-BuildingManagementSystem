namespace BuildingManagementSystem.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Web.Infrastructure;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ContactFormViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашите имена")]
        [StringLength(50, ErrorMessage = LasttNameErrorMessage, MinimumLength = 8)]
        [Display(Name = "Вашите имена")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият email адрес")]
        [EmailAddress(ErrorMessage = "Моля въведете валиден email адрес")]
        [Display(Name = "Вашият е-мейл адрес")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият телефонен номер")]
        [Phone]
        [RegularExpression(@"^[+]{1}[3][5][9][0-9]{9}$", ErrorMessage = PhoneNumberErrorMessage)]
        [Display(Name = "Мобилен телефонен номер")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете заглавие на съобщението")]
        [StringLength(100, ErrorMessage = "Заглавието трябва да е поне {2} и не повече от {1} символа.", MinimumLength = 5)]
        [Display(Name = "Заглавие на съобщението")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете съдържание на съобщението")]
        [StringLength(10000, ErrorMessage = "Съобщението трябва да е поне {2} символа.", MinimumLength = 20)]
        [Display(Name = "Съдържание на съобщението")]
        public string Content { get; set; }

        [GoogleReCaptchaValidation]
        public string RecaptchaValue { get; set; }
    }
}
