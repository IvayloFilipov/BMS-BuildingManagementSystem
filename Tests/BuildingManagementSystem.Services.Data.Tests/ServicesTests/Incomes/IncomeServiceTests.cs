namespace BuildingManagementSystem.Services.Data.Tests.Incomes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Data.Models.BuildingIncomes;
    using BuildingManagementSystem.Services.Data.Incomes;
    using BuildingManagementSystem.Services.Data.Tests.Mocks;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;

    public class IncomeServiceTests
    {
        [Fact]
        public void AddIncome()
        {
        }

        [Fact]
        public void GetAllPropertiesReturnsAllOfTheAvailablePropeties()
        {
            // Arrange
            using var data = DataBaseMock.Instance;

            data.Properties.AddRange(Enumerable.Range(1, 3).Select(x => new Property()));
            data.SaveChanges();

            var incomeService = new IncomeService(data);

            // Act
            var result = incomeService.GetAllProperties();

            // Assert
            Assert.NotNull(result);
            
            // var viewResult = Assert.IsAssignableFrom<Task<IEnumerable<GetPropertyDataFormModel>>>(result);

            // var viewResult = Assert.IsType<ViewResult>(result);
            // var model = viewResult.Result;

            // var indexViewModel = Assert.IsType<GetPropertyDataFormModel>(model);
        }

        [Fact]
        public void GetPaymentTypesShoulReturnAllPaymentTypes()
        {
            // Arrange
            const string paymentType = "В брой";

            using var data = DataBaseMock.Instance;

            data.PaymentTypes.Add(new PaymentType { Type = paymentType });
            data.SaveChanges();

            var incomeService = new IncomeService(data);

            // Act
            var result = incomeService.GetPaymentType();

            // Assert
            Assert.NotNull(result);
        }
    }
}
