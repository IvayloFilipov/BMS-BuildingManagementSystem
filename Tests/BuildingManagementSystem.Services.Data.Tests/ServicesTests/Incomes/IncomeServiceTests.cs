namespace BuildingManagementSystem.Services.Data.Tests.Incomes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Data.Models.BuildingIncomes;
    using BuildingManagementSystem.Services.Data.Incomes;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;
    using Xunit;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class IncomeServiceTests
    {
        [Fact]
        public void AddIncomeShouldAddTheIncomeIntoTheCorrectBuildingAccount()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;

            var bankAccount = new BuildingManagementSystem.Data.Models.BuildingFunds.Account() { AccountType = UbbBankAccountType, Id = 5 };

            dbContext.BuildingAccounts.Add(bankAccount);

            var cashAccount = new BuildingManagementSystem.Data.Models.BuildingFunds.Account() { AccountType = CashAccounType, Id = 12 };

            dbContext.BuildingAccounts.Add(cashAccount);

            dbContext.SaveChanges();

            var incomeService = new IncomeService(dbContext);
            var initialAccountAmount = bankAccount.TotalAmount;

            // Act
            var result = incomeService.AddIncomeAsync(10, "Описание", "Иван", "за м. Август", 1, 1).GetAwaiter().GetResult();

            // Assert
            Assert.Equal(10, result);
            Assert.NotEmpty(dbContext.IncomingPayments);

            var payment = dbContext.IncomingPayments.Last();

            Assert.Equal(bankAccount.Id, payment.AccountId);
            Assert.Equal(10, payment.Amount);
            Assert.Equal("Описание", payment.IncomeDescription);

            Assert.Equal(initialAccountAmount + 10, bankAccount.TotalAmount);
        }

        [Fact]
        public void GetAllPropertiesReturnsAllOfTheAvailablePropeties()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;

            dbContext.Properties.AddRange(Enumerable.Range(1, 3).Select(x => new Property() { PropertyFloor = new PropertyFloor(), PropertyType = new PropertyType() }));
            dbContext.SaveChanges();

            var incomeService = new IncomeService(dbContext);

            // Act
            var result = incomeService.GetAllProperties().GetAwaiter().GetResult();

            // Assert
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task GetPaymentTypesShoulReturnAllPaymentTypes()
        {
            // Arrange
            const string paymentType = "В брой";

            using var dbContext = DataBaseMock.Instance;

            dbContext.PaymentTypes.Add(new PaymentType { Type = paymentType });
            dbContext.SaveChanges();

            var incomeService = new IncomeService(dbContext);

            // Act
            var result = await incomeService.GetPaymentType();

            // Assert
            Assert.Single(result);
            Assert.Equal(paymentType, result.First().PaymentType);
        }

        // Payment types to seed
        public List<PaymentType> AllTypes()
        {
            return new List<PaymentType>
            {
                new PaymentType
                {
                    Type = "Cash",
                },
                new PaymentType
                {
                    Type = "Bank",
                },
            };
        }

        [Fact]
        public async Task GetPaymentTypesShoulReturnTheAllPaymentTypes()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;

            foreach (var paymentType in this.AllTypes())
            {
                dbContext.Add(paymentType);
            }

            dbContext.SaveChanges();

            var incomeService = new IncomeService(dbContext);

            // Act
            var result = await incomeService.GetPaymentType();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Collection(result, new System.Action<PaymentTypeDataModel>[] { ptdm => Assert.Equal("Cash", ptdm.PaymentType), ptdm => Assert.Equal("Bank", ptdm.PaymentType) });
            Assert.All(result, x => Assert.NotNull(x.PaymentType));
        }
    }
}
