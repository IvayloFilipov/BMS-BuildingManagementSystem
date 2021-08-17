namespace BuildingManagementSystem.Services.Data.Reports
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.ManagerModules.Reports;
    using Microsoft.EntityFrameworkCore;

    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext dbContext;

        public ReportService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<PaidExpensesViewModel>> PaidExpencesReportAsync()
        {
            var expenses = await this.dbContext
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
                .ToListAsync();

            return expenses;
        }

        public async Task<IEnumerable<PaidIncomesViewModel>> PaidIncomesReportAsync()
        {
            var incomes = await this.dbContext
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
                .ToListAsync();

            return incomes;
        }

        public async Task<IEnumerable<AccountsValueViewModel>> GetValuesAsync()
        {
            var value = await this.dbContext
                .BuildingAccounts
                .Select(x => new AccountsValueViewModel
                {
                    Id = x.Id,
                    AccountType = x.AccountType,
                    TotalAmount = x.TotalAmount,
                })
                .ToListAsync();

            return value;
        }
    }
}
