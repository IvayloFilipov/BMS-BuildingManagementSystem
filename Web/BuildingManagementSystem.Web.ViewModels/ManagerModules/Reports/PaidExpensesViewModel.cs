namespace BuildingManagementSystem.Web.ViewModels.ManagerModules.Reports
{
    using System;

    public class PaidExpensesViewModel
    {
        public int Id { get; set; }

        // public int ExpenseTypeId { get; set; }
        public string ExpenseType { get; set; }

        public decimal Amount { get; set; }

        public string CreatedOnYear { get; set; }

        public string CreatedOnMonth { get; set; }
    }
}
