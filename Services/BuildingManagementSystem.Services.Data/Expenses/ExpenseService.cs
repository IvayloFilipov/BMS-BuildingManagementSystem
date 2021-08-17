namespace BuildingManagementSystem.Services.Data.Expenses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingExpenses;
    using BuildingManagementSystem.Data.Models.BuildingFunds;
    using BuildingManagementSystem.Web.ViewModels.Expenses.ManagerModules;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;
    using Microsoft.EntityFrameworkCore;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<decimal> PayExpenseAsync(int expenseTypeId, int paymentTypeId, decimal amount, string description)
        {
            Account buildingAccount;
            switch (paymentTypeId)
            {
                case 1:
                    // bank payment - hardcoded
                    buildingAccount = this.dbContext.BuildingAccounts.FirstOrDefault(x => x.AccountType == UbbBankAccountType);
                    break;
                case 2:
                    // cash payment
                    buildingAccount = this.dbContext.BuildingAccounts.FirstOrDefault(x => x.AccountType == CashAccounType);
                    break;
                default:
                    throw new ArgumentException($"Невалиден тип на плащане {paymentTypeId}", nameof(paymentTypeId));
            }

            var currOutgoingPayment = new Transaction
            {
                ExpenseTypeId = expenseTypeId,
                PaymentTypeId = paymentTypeId,
                Amount = amount,
                Description = description,
                AccountId = buildingAccount.Id,
            };

            // The App throws exception and stop
            // if (buildingAccount.TotalAmount < amount)
            // {
            //     throw new InvalidOperationException("Недостатъчна наличност по сметката!");
            // }
            await this.dbContext.OutgoingPayments.AddAsync(currOutgoingPayment);

            buildingAccount.TotalAmount -= amount;

            await this.dbContext.SaveChangesAsync();

            return currOutgoingPayment.Amount;
        }

        public async Task<IEnumerable<ExpenseTypeDataModel>> GetExpenseType()
        {
            var expenseType = await this.dbContext
                .ExpenseTypes
                .Select(x => new ExpenseTypeDataModel
                {
                    Id = x.Id,
                    Type = x.Type,
                })
                .ToListAsync();

            return expenseType;
        }

        public async Task<IEnumerable<PaymentTypeDataModel>> GetExpensePaymentType()
        {
            var paymentType = await this.dbContext
                .PaymentTypes
                .Select(x => new PaymentTypeDataModel
                {
                    Id = x.Id,
                    PaymentType = x.Type,
                })
                .ToListAsync();

            return paymentType;
        }
    }
}
