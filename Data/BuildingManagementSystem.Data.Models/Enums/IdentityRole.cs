namespace BuildingManagementSystem.Data.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum IdentityRole
    {
        [Display(Name = "Администратор")]
        Admin = 10,

        [Display(Name = "Собственик")]
        Owner = 20,

        [Display(Name = "Наемател")]
        Tenant = 30,

        [Display(Name = "Гост")]
        Guest = 40,
    }
}
