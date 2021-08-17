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
        public async Task<IActionResult> GetPaidExpenses()
        {
            var allPaidExpenses = await this.reportService.PaidExpencesReportAsync();

            return this.View(allPaidExpenses);
        }

        [Authorize(Roles = "Admin, Owner, Tenant")]
        public async Task<IActionResult> GetIncomes()
        {
            var allPaidIncomes = await this.reportService.PaidIncomesReportAsync();

            return this.View(allPaidIncomes);
        }

        [Authorize(Roles = "Admin, Owner, Tenant")]
        public async Task<IActionResult> GetValues()
        {
            var allValues = await this.reportService.GetValuesAsync();

            return this.View(allValues);
        }
    }
}
