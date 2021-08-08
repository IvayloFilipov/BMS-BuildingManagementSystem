namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models;
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

        public ManagerController(UserManager<ApplicationUser> userManager, IExpenseService expenseService, IIncomeService incomeService)
        {
            this.userManager = userManager;
            this.expenseService = expenseService;
            this.incomeService = incomeService;
        }

        public IActionResult AddIncomeAsync()
        {
            return this.View(new AddIncomeViewModel
            {
                Payments = this.incomeService.GetPaymentType(),
                Floors = this.incomeService.GetPropertyFloor(),
                Properties = this.incomeService.GetPropertyType(),
            });
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddIncomeAsync(AddIncomeViewModel income)
        {
            if (!this.ModelState.IsValid)
            {
                income.Payments = this.incomeService.GetPaymentType();
                income.Floors = this.incomeService.GetPropertyFloor();
                income.Properties = this.incomeService.GetPropertyType();

                return this.View(income);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

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

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult SubtractFromAccount() // Subtract from selected account
        {
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
