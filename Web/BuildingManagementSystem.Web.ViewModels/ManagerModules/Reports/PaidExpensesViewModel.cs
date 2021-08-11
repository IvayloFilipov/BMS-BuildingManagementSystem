namespace BuildingManagementSystem.Web.ViewModels.ManagerModules.Reports
{
    public class PaidExpensesViewModel
    {
        public int Id { get; set; }

        public string ExpenseType { get; set; }

        public decimal Amount { get; set; }

        public string CreatedOnYear { get; set; }

        public string CreatedOnMonth { get; set; }

        public string Description { get; set; }

        public string PaymentType { get; set; }
    }
}
