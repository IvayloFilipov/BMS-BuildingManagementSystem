namespace BuildingManagementSystem.Data.Models.BuildingFunds
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Data.Models.BuildingExpenses;
    using BuildingManagementSystem.Data.Models.BuildingIncomes;

    public class Account : BaseDeletableModel<int>
    {
        public Account()
        {
            this.IncomingPayments = new HashSet<Payment>();
            this.OutgoingPayments = new HashSet<Transaction>();
        }

        // cash account & bank account
        [Required]
        [MaxLength(20)]
        public string AccountType { get; set; }

        // total curr amount in cash & total curr amount in bank
        public decimal TotalAmount { get; set; }

        // one-to-many with Building
        public int BuildingId { get; set; }

        public virtual Building Buildings { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        // many-to-one with Payment
        public virtual ICollection<Payment> IncomingPayments { get; set; }

        // many-to-one with Transaction
        public virtual ICollection<Transaction> OutgoingPayments { get; set; }
    }
}
