namespace BuildingManagementSystem.Services.Data.Incomes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingFunds;
    using BuildingManagementSystem.Data.Models.BuildingIncomes;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;
    using Microsoft.EntityFrameworkCore;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class IncomeService : IIncomeService
    {
        private readonly ApplicationDbContext dbContext;

        public IncomeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<decimal> AddIncomeAsync(decimal amount, string incomeDescription, string payerName, string paymentPeriod, int propertyId, int paymentTypeId)
        {
            Account buildingAccount;
            switch (paymentTypeId)
            {
                case 1:
                    buildingAccount = this.dbContext.BuildingAccounts.Where(x => x.AccountType == UbbBankAccountType).FirstOrDefault();
                    break;
                case 2:
                    buildingAccount = this.dbContext.BuildingAccounts.Where(x => x.AccountType == CashAccounType).FirstOrDefault();
                    break;
                default:
                    throw new ArgumentException($"Невалиден тип на плащане {paymentTypeId}", nameof(paymentTypeId));
            }

            var currIncome = new Payment
            {
                Amount = amount,
                IncomeDescription = incomeDescription,
                PayerName = payerName,
                PaymentPeriod = paymentPeriod,
                PropertyId = propertyId,
                PaymentTypeId = paymentTypeId,
                AccountId = buildingAccount.Id,
            };

            await this.dbContext.IncomingPayments.AddAsync(currIncome);

            buildingAccount.TotalAmount += amount;

            await this.dbContext.SaveChangesAsync();

            return currIncome.Amount;
        }

        public async Task<IEnumerable<GetPropertyDataFormModel>> GetAllProperties()
        {
            var properties = await this.dbContext
                .Properties
                .Select(x => new GetPropertyDataFormModel
                {
                    Id = x.Id,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number,
                })
                .ToListAsync();

            return properties;
        }

        public async Task<IEnumerable<PaymentTypeDataModel>> GetPaymentType()
        {
            var payments = await this.dbContext
                .PaymentTypes
                .Select(x => new PaymentTypeDataModel
                {
                    Id = x.Id,
                    PaymentType = x.Type,
                })
                .ToListAsync();

            return payments;
        }
    }
}
