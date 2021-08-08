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

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<decimal> PayExpenseAsync(int expenseTypeId, int paymentTypeId, decimal amount, string descrition)
        {
            Account bankAccount;
            switch (paymentTypeId)
            {
                case 1:
                    // bank payment - hardcodded
                    bankAccount = this.dbContext.BuildingAccounts.FirstOrDefault(x => x.AccountType == UbbBankAccountType);
                    break;
                case 2:
                    // cash
                    bankAccount = this.dbContext.BuildingAccounts.FirstOrDefault(x => x.AccountType == CashAccounType);
                    break;
                default:
                    throw new ArgumentException($"Невалиден тип на плащане {paymentTypeId}", nameof(paymentTypeId));
            }

            var payment = new Transaction
            {
                ExpenseTypeId = expenseTypeId,
                PaymentTypeId = paymentTypeId,
                Amount = amount,
                Description = descrition,
                AccountId = bankAccount.Id,
            };
            try
            {
                await this.dbContext.OutgoingPayments.AddAsync(payment);

                bankAccount.TotalAmount -= amount;
            }
            catch (Exception)
            {

                throw;
            }
            if (bankAccount.TotalAmount < amount)
            {
                throw new InvalidOperationException("Недостатъчна наличност по сметката!");
            }

            await this.dbContext.OutgoingPayments.AddAsync(payment);

            bankAccount.TotalAmount -= amount;

            await this.dbContext.SaveChangesAsync();

            return payment.Amount;
        }

        public IEnumerable<ExpenseTypeDataModel> GetExpenseType()
        {
            var expenseType = this.dbContext
                .ExpenseTypes
                .Select(x => new ExpenseTypeDataModel
                {
                    Id = x.Id,
                    Type = x.Type,
                })
                .ToList();

            return expenseType;
        }

        public IEnumerable<PaymentTypeDataModel> GetExpensePaymentType()
        {
            var paymentType = this.dbContext
                .PaymentTypes
                .Select(x => new PaymentTypeDataModel
                {
                    Id = x.Id,
                    PaymentType = x.Type,
                })
                .ToList();

            return paymentType;
        }
    }
}
