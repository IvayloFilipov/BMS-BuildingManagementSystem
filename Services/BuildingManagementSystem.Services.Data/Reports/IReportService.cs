namespace BuildingManagementSystem.Services.Data.Reports
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.ManagerModules.Reports;

    public interface IReportService
    {
        Task<IEnumerable<PaidExpensesViewModel>> PaidExpencesReportAsync();

        Task<IEnumerable<PaidIncomesViewModel>> PaidIncomesReportAsync();

        Task<IEnumerable<AccountsValueViewModel>> GetValuesAsync();
    }
}
