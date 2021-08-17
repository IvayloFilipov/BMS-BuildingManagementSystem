namespace BuildingManagementSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Services.Data.Reports;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ReportsController : BaseController
    {
        private readonly IReportService reportService;

        public ReportsController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [Authorize(Roles = "Admin, Owner, Tenant")]
        public IActionResult GetPaidExpenses()
        {
            var allPaidExpenses = this.reportService.PaidExpencesReport();

            return this.View(allPaidExpenses);
        }

        [Authorize(Roles = "Admin, Owner, Tenant")]
        public IActionResult GetIncomes()
        {
            var allPaidIncomes = this.reportService.PaidIncomesReport();

            return this.View(allPaidIncomes);
        }

        [Authorize(Roles = "Admin, Owner, Tenant")]
        public IActionResult GetValues()
        {
            var allValues = this.reportService.GetValuesAsync();

            return this.View(allValues);
        }
    }
}
