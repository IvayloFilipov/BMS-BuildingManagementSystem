namespace BuildingManagementSystem.Services.Data.Expenses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingExpenses;
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
            var selectedExpenseTypeId = this.dbContext
                .ExpenseTypes
                .Where(x => x.Id == expenseTypeId)
                .Select(x => x.Id)
                .FirstOrDefault();

            var selectedPaymentTypeId = this.dbContext
                .PaymentTypes
                .Where(x => x.Id == paymentTypeId)
                .Select(x => x.Id)
                .FirstOrDefault();

            var payment = new Transaction
            {
                ExpenseTypeId = selectedExpenseTypeId,
                PaymentTypeId = selectedPaymentTypeId,
                Amount = amount,
                Description = descrition,
            };

            await this.dbContext.OutgoingPayments.AddAsync(payment);

            await this.dbContext.SaveChangesAsync();

            return payment.Amount;
        }

        public void SubtractFromAccountAsync(string paymentType, decimal currAmoun)
        {
            var amountToSubtract = currAmoun; // ?????

            var moneyInBankAccount = this.dbContext
                .BuildingAccounts
                .Where(x => x.AccountType == UbbBankAccountType)
                .Select(x => x.TotalAmount)
                .FirstOrDefault();

            var moneyInCashAccount = this.dbContext
                .BuildingAccounts
                .Where(x => x.AccountType == CashAccounType)
                .Select(x => x.TotalAmount)
                .FirstOrDefault();

            try
            {
                if (paymentType == UbbBankAccountType && moneyInBankAccount >= amountToSubtract)
                {
                    moneyInBankAccount -= amountToSubtract;
                }
                else if (paymentType == CashAccounType && moneyInCashAccount >= amountToSubtract)
                {
                    moneyInCashAccount -= amountToSubtract;
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Недостатъчна наличност по сметката!");
            }

            // if (paymentType == UbbBankAccountType && moneyInBankAccount >= amountToSubtract)
            // {
            //     moneyInBankAccount -= amountToSubtract;
            // }
            // else if (paymentType == CashAccounType && moneyInCashAccount >= amountToSubtract)
            // {
            //     moneyInCashAccount -= amountToSubtract;
            // }
            // else
            // {
            //     throw new InvalidOperationException("Недостатъчна наличност по сметката!");
            // }

            this.dbContext.SaveChanges();
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
