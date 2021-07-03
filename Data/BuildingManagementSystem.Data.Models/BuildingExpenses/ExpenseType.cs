namespace BuildingManagementSystem.Data.Models.BuildingExpenses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ExpenseType
    {
        public int Id { get; set; }

        // Elevator, Cleaning, ManagementFee, BankFee, ElectricityElevator, ElectricityStairs, OtherExpenses -> should be describe into field Description
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        // many-to-one - many Transactions can have one expense type
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
