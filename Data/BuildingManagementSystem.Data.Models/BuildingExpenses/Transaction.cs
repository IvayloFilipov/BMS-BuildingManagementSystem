namespace BuildingManagementSystem.Data.Models.BuildingExpenses
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;
    using BuildingManagementSystem.Data.Models.BuildingFunds;
    using BuildingManagementSystem.Data.Models.BuildingIncomes;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class Transaction : BaseModel<int>
    {
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(TransactionDescriptionMaxLength)]
        public string Description { get; set; }

        // one-to-many with ExpenseType -> ElevatorFee, Cleaning, etc...
        [Required]
        public int ExpenseTypeId { get; set; }

        public ExpenseType ExpenseType { get; set; }

        // one-to-many with PaymentType
        public int? PaymentTypeId { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        // one-to-many with Account
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
