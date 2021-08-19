namespace BuildingManagementSystem.Services.Data.Tests.ServicesTests.Expenses
{
    using System.Linq;

    using BuildingManagementSystem.Services.Data.Expenses;
    using BuildingManagementSystem.Services.Data.Tests.Mock;
    using Xunit;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ExpenseServiceTests
    {
        [Fact]
        public void PayExpenseAsyncShouldRemoveTheAmmountFromTheSelectedBuildingAccount()
        {
            // Arrange
            using var dbContext = DataBaseMock.Instance;

            var bankAccount = new BuildingManagementSystem.Data.Models.BuildingFunds.Account() { AccountType = UbbBankAccountType, Id = 5 };

            dbContext.BuildingAccounts.Add(bankAccount);

            var cashAccount = new BuildingManagementSystem.Data.Models.BuildingFunds.Account() { AccountType = CashAccounType, Id = 12 };

            dbContext.BuildingAccounts.Add(cashAccount);

            dbContext.SaveChanges();

            var incomeService = new ExpenseService(dbContext);
            var initialAccountAmount = bankAccount.TotalAmount;

            // Act
            var result = incomeService.PayExpenseAsync(1, 1, 10, "Почистване").GetAwaiter().GetResult();

            // Assert
            Assert.Equal(10, result);
            Assert.NotEmpty(dbContext.OutgoingPayments);

            var payment = dbContext.OutgoingPayments.Last();

            Assert.Equal(bankAccount.Id, payment.AccountId);
            Assert.Equal(10, payment.Amount);
            Assert.Equal("Почистване", payment.Description);

            Assert.Equal(initialAccountAmount - 10, bankAccount.TotalAmount);
        }
    }
}
