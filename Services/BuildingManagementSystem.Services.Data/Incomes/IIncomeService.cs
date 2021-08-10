namespace BuildingManagementSystem.Services.Data.Incomes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;

    public interface IIncomeService
    {
        Task<decimal> AddIncomeAsync(string incomeDescription, int paymentTypeId, decimal amount, string paymentPeriod, int propertyId, int propertyFloorId, int propertyNumber, string payerName);

        Task AddToAccountAsync();

        IEnumerable<Property> GetAllProperties();

        public IEnumerable<PaymentTypeDataModel> GetPaymentType();

        public IEnumerable<PropertyFloorDataModel> GetPropertyFloor();

        public IEnumerable<PropertyTypeDataModel> GetPropertyType();
    }
}
