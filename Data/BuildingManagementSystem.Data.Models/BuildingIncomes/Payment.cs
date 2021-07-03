namespace BuildingManagementSystem.Data.Models.BuildingIncomes
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Data.Models.BuildingFunds;

    public class Payment : BaseModel<int>
    {
        public decimal Amount { get; set; }

        [MaxLength(250)]
        public string PaymentPeriod { get; set; }

        // one-to-many with Property - one Property can make many(every month) payments
        public int? PropertyId { get; set; }

        public virtual Property Property { get; set; }

        // one-to-many with PaymentType - one type of payment can be made by many Properties
        public int? PaymentTypeId { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        // one-to-many with Account - one payment can be paid to many Accounts (cash, bank) every month
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
