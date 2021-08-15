namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Services.Data.DeleteOwners;
    using BuildingManagementSystem.Services.Data.Edits;
    using BuildingManagementSystem.Services.Data.Expenses;
    using BuildingManagementSystem.Services.Data.Incomes;
    using BuildingManagementSystem.Web.ViewModels.Expenses.ManagerModules;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;
    using BuildingManagementSystem.Web.ViewModels.Properties;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ManagerController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IExpenseService expenseService;
        private readonly IIncomeService incomeService;
        private readonly IEditPropertyService editPropertyService;
        private readonly IDeleteOwnerService deleteOwnerService;

        public ManagerController(
            UserManager<ApplicationUser> userManager,
            IExpenseService expenseService,
            IIncomeService incomeService,
            IEditPropertyService editPropertyService,
            IDeleteOwnerService deleteOwnerService)
        {
            this.userManager = userManager;
            this.expenseService = expenseService;
            this.incomeService = incomeService;
            this.editPropertyService = editPropertyService;
            this.deleteOwnerService = deleteOwnerService;
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
        public async Task<IActionResult> EditProperty(int id)
        {
            var selectedProperty = await this.editPropertyService.SelectedPropertyAsync(id);

            var propertyToEdit = new EditPropertyViewModel
            {
                // UserId = selectedProperty.UserId,
                // IsSold = selectedProperty.IsSold,
                Id = selectedProperty.Id,
                PropertyType = selectedProperty.PropertyType,
                PropertyFloor = selectedProperty.PropertyFloor,
                PropertyNumber = selectedProperty.PropertyNumber,
                CoOwner = selectedProperty.CoOwner,
                DogCount = selectedProperty.DogCount,
                StatusId = selectedProperty.StatusId,
                Statuses = this.editPropertyService.GetPropertyStatus(),
            };

            return this.View(propertyToEdit);
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditProperty(EditPropertyViewModel currProperty)
        {
            if (!this.ModelState.IsValid)
            {
                currProperty.Statuses = this.editPropertyService.GetPropertyStatus();

                return this.View(currProperty);
            }

            await this.editPropertyService.EditAsync(currProperty.Id, currProperty.CoOwner, currProperty.DogCount, currProperty.StatusId/*, currProperty.IsSold, currProperty.UserId*/);

            return this.RedirectToAction(nameof(this.GetAllProperties));
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult GetOwners()
        {
            var allOwners = this.deleteOwnerService.GetAllOwners();

            return this.View(allOwners);
        }

        // [Authorize(Roles = "Admin")]
        public IActionResult DeleteOwner(int id)
        {
            this.deleteOwnerService.RemoveOwner(id);

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
