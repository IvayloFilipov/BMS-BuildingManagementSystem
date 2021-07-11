namespace BuildingManagementSystem.Data.Models.BuildingExpenses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ExpenseType : BaseDeletableModel<int>
    {
        // Elevator, Cleaning, ManagementFee, BankFee, ElectricityElevator, ElectricityStairs, OtherExpenses -> should be describe into field Description
        [Required]
        [MaxLength(ExpenseTypeMaxLength)]
        public string Type { get; set; }

        // many-to-one - many Transactions can have one expense type
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
