namespace BuildingManagementSystem.Data.Models.Debts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    public class PropertyStatus : BaseDeletableModel<int>
    {
        public PropertyStatus()
        {
            this.CurrMonthPropertyStatus = new HashSet<PropertyDebt>();
        }

        // Occupied/Обитаем, Unoccupied/Необитаем, Commertial/С търг. дейност
        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        // many-to-one with MonthlyDebt - many Properties can have one type of Status at a time
        public virtual ICollection<PropertyDebt> CurrMonthPropertyStatus { get; set; }
    }
}
