namespace BuildingManagementSystem.Services.Data.Incomes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;

    public interface IIncomeService
    {
        Task<decimal> AddIncomeAsync();

        Task AddToAccountAsync();

        IEnumerable<Property> GetAllProperties();

        public IEnumerable<PaymentTypeDataModel> GetPaymentType();

        public IEnumerable<PropertyFloorDataModel> GetPropertyFloor();

        public IEnumerable<PropertyTypeDataModel> GetPropertyType();
    }
}
