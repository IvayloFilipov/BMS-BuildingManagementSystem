namespace BuildingManagementSystem.Services.Data.Reports
{
    using System.Collections.Generic;

    using BuildingManagementSystem.Web.ViewModels.ManagerModules.Reports;

    public interface IReportService
    {
        IEnumerable<PaidExpensesViewModel> PaidExpencesReport();

        IEnumerable<PaidIncomesViewModel> PaidIncomesReport();

        IEnumerable<AccountsValueViewModel> GetValuesAsync();
    }
}
