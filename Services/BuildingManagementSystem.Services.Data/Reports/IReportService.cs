namespace BuildingManagementSystem.Services.Data.Reports
{
    using System;
    using System.Collections.Generic;

    using BuildingManagementSystem.Web.ViewModels.ManagerModules.Reports;

    public interface IReportService
    {
        public IEnumerable<PaidExpensesViewModel> PaidExpencesReport();

        void IncomesDebdsReport();
    }
}
