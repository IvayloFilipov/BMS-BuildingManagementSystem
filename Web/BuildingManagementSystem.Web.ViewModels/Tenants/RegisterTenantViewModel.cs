namespace BuildingManagementSystem.Web.ViewModels.Tenants
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Services.Mapping;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class RegisterTenantViewModel : IMapFrom<Tenant>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете името на наемателя")]
        [StringLength(TenantFirstNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = 3)]
        [Display(Name = "Име на наемателя")]
        public string FirstName { get; set; }

        [StringLength(TenantMiddleNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = 4)]
        [Display(Name = "Презиме на наемателя")]
        public string MiddleName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете фамилията на наемателя")]
        [StringLength(TenantLastNameMaxLength, ErrorMessage = FirstNameErrorMessage, MinimumLength = 4)]
        [Display(Name = "Фамилия на наемателя")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете Е-мейла на наемателя")]
        [EmailAddress(ErrorMessage = "Моля въведете валиден email адрес")]
        [StringLength(TenantEmailMaxLength)]
        [Display(Name = "Е-мейл на наемателя")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете мобилният телефонен номер на наемателя")]
        [Phone]
        [RegularExpression(@"^[+]{1}[3][5][9][0-9]{9}$", ErrorMessage = PhoneNumberErrorMessage)]
        [Display(Name = "Мобилен телефонен номер на наемателя")]
        public string Phone { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
