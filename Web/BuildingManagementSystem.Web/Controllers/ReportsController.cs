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

        // [Authorize(Roles = "Admin")]
        public IActionResult GetPaidExpenses()
        {
            var allPaidExpenses = this.reportService.PaidExpencesReport();

            return this.View(allPaidExpenses);
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult GetIncomes()
        {
            var allPaidIncomes = this.reportService.PaidIncomesReport();

            return this.View(allPaidIncomes);
        }
    }
}
