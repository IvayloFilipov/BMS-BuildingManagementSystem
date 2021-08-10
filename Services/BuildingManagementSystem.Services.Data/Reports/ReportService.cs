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
            //var expenses = this.dbContext
            //    .OutgoingPayments
            //    .Select(x => new PaidExpensesViewModel
            //    {
            //        Id = x.Id,
            //        Amount = x.Amount,
            //        ExpenseTypeId = x.ExpenseTypeId,
            //        CreatedOnYear = x.CreatedOn.ToString("yyyy"),
            //        CreatedOnMonth = x.CreatedOn.ToString("MMMM"),
            //    })
            //    .ToList();
            var expenses = this.dbContext
                .OutgoingPayments
                .Select(x => new PaidExpensesViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    ExpenseType = x.ExpenseType.Type,
                    CreatedOnYear = x.CreatedOn.ToString("yyyy"),
                    CreatedOnMonth = x.CreatedOn.ToString("MMMM"),
                })
                .ToList();

            return expenses;
        }

        public void IncomesDebdsReport()
        {
            throw new NotImplementedException();
        }
    }
}
