namespace BuildingManagementSystem.Data.Models.BuildingIncomes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Models.BuildingExpenses;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class PaymentType
    {
        public PaymentType()
        {
            this.TypeOfPayment = new HashSet<Payment>();
            this.TypeOfTransaction = new HashSet<Transaction>();
        }

        [Key]
        public int Id { get; set; }

        // cash(в брой), bank(банков превод), easyPay,...
        [Required]
        [MaxLength(PaymentTypeMaxLength)]
        public string Type { get; set; }

        // many-to-one - many incoming payments can have one type payment
        public virtual ICollection<Payment> TypeOfPayment { get; set; }

        // many-to-one - many outgoing payments can have one type payment
        public virtual ICollection<Transaction> TypeOfTransaction { get; set; }
    }
}
