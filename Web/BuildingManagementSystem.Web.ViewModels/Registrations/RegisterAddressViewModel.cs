namespace BuildingManagementSystem.Web.ViewModels.Registrations
{
    using System.ComponentModel.DataAnnotations;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class RegisterAddressViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете името на града")]
        [StringLength(30, ErrorMessage = CityNameErrorMessage, MinimumLength = 3)]
        [Display(Name = "Град")]
        public string City { get; set; }

        // [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете името на квартала")]
        [StringLength(DistrictMaxLength, ErrorMessage = DistrictNameErrorMessage, MinimumLength = 3)]
        [Display(Name = "Квартал")]
        public string District { get; set; }

        // [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете пощенския код")]
        [StringLength(4, ErrorMessage = ZipCodeErrorMessage, MinimumLength = 4)]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Невалиден пощенски код")]
        [Display(Name = "Пощенски код")]
        public string ZipCode { get; set; }

        [StringLength(StreetMaxLength, MinimumLength = 5)]
        [Display(Name = "Име на улицата")]
        public string Street { get; set; }

        [StringLength(StreetNumberMaxLength, MinimumLength = 1)]
        [Display(Name = "Номер на улицата")]
        public string StreetNumber { get; set; }

        [StringLength(BlockNumberMaxLength, MinimumLength = 1)]
        [Display(Name = "Номер на блока")]
        public string BlockNumber { get; set; }

        [StringLength(EntranceNumberMaxLength, MinimumLength = 1)]
        [Display(Name = "Номер на входа")]
        public string EntranceNumber { get; set; }

        [StringLength(FloorNumberMaxLength, MinimumLength = 1)]
        [Display(Name = "Номер на етажа")]
        public int? Floor { get; set; }

        [StringLength(ApprtmentNumberMaxLength, MinimumLength = 1)]
        [Display(Name = "Номер на апартамента")]
        public int? AppartNumber { get; set; }
    }
}
