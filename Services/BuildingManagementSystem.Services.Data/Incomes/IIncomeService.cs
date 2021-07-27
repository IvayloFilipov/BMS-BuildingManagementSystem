namespace BuildingManagementSystem.Services.Data.Incomes
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingData;

    public interface IIncomeService
    {
        Task AddIncomeAsync();

        IEnumerable<Property> GetAllProperties();
    }
}
