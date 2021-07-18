namespace BuildingManagementSystem.Data.Models.Debts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class Fee : BaseDeletableModel<int>
    {
        public Fee()
        {
            this.PropertyDebts = new HashSet<PropertyDebt>();
        }

        public double Amount { get; set; }

        // Fees - Намалена/reduced(10 lv), Нормална/regular(20 lv), Увеличена/increased(80 lv)
        [Required]
        [MaxLength(FeeTypeMaxLength)]
        public string Type { get; set; }

        [MaxLength(FeeDescriptionMaxLength)]
        public string Description { get; set; }

        // many-to-one with PropertyDebt
        public virtual ICollection<PropertyDebt> PropertyDebts { get; set; }
    }
}
