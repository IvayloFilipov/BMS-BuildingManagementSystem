namespace BuildingManagementSystem.Services.Data.Reports
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.ManagerModules.Reports;

    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext dbContext;

        public ReportService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<PaidExpensesViewModel> PaidExpencesReport()
        {
            var expenses = this.dbContext
                .OutgoingPayments
                .Select(x => new PaidExpensesViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    ExpenseType = x.ExpenseType.Type,
                    CreatedOnYear = x.CreatedOn.ToString("yyyy"),
                    CreatedOnMonth = x.CreatedOn.ToString("MMMM"),
                    Description = x.Description,
                    PaymentType = x.PaymentType.Type,
                })
                .ToList();

            return expenses;
        }

        public IEnumerable<PaidIncomesViewModel> PaidIncomesReport()
        {
            var incomes = this.dbContext
                .IncomingPayments
                .Select(x => new PaidIncomesViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    CreatedOnMonth = x.CreatedOn.ToString("MMMM"),
                    CreatedOnYear = x.CreatedOn.ToString("yyyy"),
                    IncomeDescription = x.IncomeDescription,
                    PayerName = x.PayerName,
                    PaymentPeriod = x.PaymentPeriod,
                    PaymentType = x.PaymentType.Type,
                    Property = $"етаж: {x.Property.PropertyFloor.Floor}, {x.Property.PropertyType.Type} № {x.Property.Number}".ToString(),
                })
                .ToList();

            return incomes;
        }
    }
}
