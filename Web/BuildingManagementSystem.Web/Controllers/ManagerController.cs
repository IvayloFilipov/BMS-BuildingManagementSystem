namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Services.Data.Edits;
    using BuildingManagementSystem.Services.Data.Expenses;
    using BuildingManagementSystem.Services.Data.Incomes;
    using BuildingManagementSystem.Web.ViewModels.Expenses.ManagerModules;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ManagerController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IExpenseService expenseService;
        private readonly IIncomeService incomeService;
        private readonly IEditPropertyService editPropertyService;

        public ManagerController(
            UserManager<ApplicationUser> userManager,
            IExpenseService expenseService,
            IIncomeService incomeService,
            IEditPropertyService editPropertyService)
        {
            this.userManager = userManager;
            this.expenseService = expenseService;
            this.incomeService = incomeService;
            this.editPropertyService = editPropertyService;
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult AddIncome()
        {
            return this.View(new AddIncomeViewModel
            {
                Payments = this.incomeService.GetPaymentType(),
                Properties = this.incomeService.GetAllProperties(),
            });
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddIncome(AddIncomeViewModel income)
        {
            if (!this.ModelState.IsValid)
            {
                income.Payments = this.incomeService.GetPaymentType();
                income.Properties = this.incomeService.GetAllProperties();

                return this.View(income);
            }

            // var user = await this.userManager.GetUserAsync(this.User);
            // var userId = user.Id;
            await this.incomeService.AddIncomeAsync(income.Amount, income.IncomeDescription, income.PayerName, income.PaymentPeriod, income.PropertyId, income.PaymentTypeId);

            return this.RedirectToAction(nameof(this.AddIncome));
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult PayExpense()
        {
            return this.View(new PayExpenseViewModel
            {
                Expenses = this.expenseService.GetExpenseType(),
                Payments = this.expenseService.GetExpensePaymentType(),
            });
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PayExpense(PayExpenseViewModel expenseType)
        {
            if (!this.ModelState.IsValid)
            {
                expenseType.Expenses = this.expenseService.GetExpenseType();
                expenseType.Expenses = (IEnumerable<ExpenseTypeDataModel>)this.expenseService.GetExpensePaymentType();

                return this.View(expenseType);
            }

            await this.expenseService.PayExpenseAsync(expenseType.ExpenseTypeId, expenseType.PaymentTypeId, expenseType.Amount, expenseType.Description);

            return this.RedirectToAction(nameof(this.PayExpense));
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult GetAllProperties()
        {
            var allProperties = this.editPropertyService.AllProperties();

            return this.View(allProperties);
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult EditProperty()
        {
            return this.View();
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditProperty(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return null;
        }

        public IActionResult ChangeFee() // Not implemented yet
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeFee(string fee) // <- Add view model
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
