namespace BuildingManagementSystem.Services.Data.Incomes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;

    public interface IIncomeService
    {
        Task<decimal> AddIncomeAsync(decimal amount, string incomeDescription, string payerName, string paymentPeriod, int propertyId, int paymentTypeId);

        Task<IEnumerable<GetPropertyDataFormModel>> GetAllProperties();

        Task<IEnumerable<PaymentTypeDataModel>> GetPaymentType();
    }
}
