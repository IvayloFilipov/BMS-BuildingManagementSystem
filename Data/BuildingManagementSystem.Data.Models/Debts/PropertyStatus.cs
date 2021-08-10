namespace BuildingManagementSystem.Data.Models.Debts
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class PropertyStatus : BaseDeletableModel<int>
    {
        // Occupied/Обитаем, Unoccupied/Необитаем, Commertial/С търг. дейност
        [Required]
        [MaxLength(PropertyStatusMaxLength)]
        public string Status { get; set; }
    }
}
