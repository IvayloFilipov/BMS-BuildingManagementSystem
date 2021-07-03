namespace BuildingManagementSystem.Data.Models.BuildingExpenses
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;
    using BuildingManagementSystem.Data.Models.BuildingFunds;
    using BuildingManagementSystem.Data.Models.BuildingIncomes;

    public class Transaction : BaseModel<int>
    {
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        // one-to-many with ExpenseType
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
