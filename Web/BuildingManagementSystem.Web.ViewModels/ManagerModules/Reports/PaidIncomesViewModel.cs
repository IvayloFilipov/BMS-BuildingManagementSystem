namespace BuildingManagementSystem.Web.ViewModels.ManagerModules.Reports
{
    public class PaidIncomesViewModel
    {
        public int Id { get; set; }

        public string IncomeDescription { get; set; }

        public decimal Amount { get; set; }

        public string PaymentType { get; set; }

        public string PropertyId { get; set; }

        public string PayerName { get; set; }

        public string PaymentPeriod { get; set; }

        public string CreatedOnMonth { get; set; }

        public string CreatedOnYear { get; set; }
    }
}
