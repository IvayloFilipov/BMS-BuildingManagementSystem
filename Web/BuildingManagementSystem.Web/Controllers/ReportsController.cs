namespace BuildingManagementSystem.Web.Controllers
{
    using BuildingManagementSystem.Services.Data.Reports;
    using Microsoft.AspNetCore.Mvc;

    public class ReportsController : BaseController
    {
        private readonly IReportService reportService;

        public ReportsController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        public IActionResult GetPaidExpenses()
        {
            var allPaidExpenses = this.reportService.PaidExpencesReport();

            return this.View(allPaidExpenses);
        }

        public IActionResult PivotTablePaidExpenses()
        {
            var allPaidExpenses = this.reportService.PaidExpencesReport();

            return this.View(allPaidExpenses);
        }

        public IActionResult GetIncomesDebts()
        {
            return this.View();
        }
    }
}
