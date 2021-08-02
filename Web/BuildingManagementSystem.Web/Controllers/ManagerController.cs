namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Web.ViewModels.Expenses.ManagerModules;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ManagerController : BaseController
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public ManagerController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager; // UserManager MUST be added here in the controller in order POST method to have access to User data (Id). DO NOT insert UserManager into services!!!
        }

        public IActionResult AddIncomeAsync()
        {
            return this.View(new AddIncomeViewModel
            {
                Payments = this.GetPaymentType(),
                Floors = this.GetPropertyFloor(),
                Properties = this.GetPropertyType(),

                // Properties = this.GetSomePartsFromProperty(),
            });
        }

        // Example how to get User Id
        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddIncomeAsync(AddIncomeViewModel income)
        {
            if (!this.ModelState.IsValid)
            {
                income.Payments = this.GetPaymentType();
                income.Floors = this.GetPropertyFloor();
                income.Properties = this.GetPropertyType();
                // income.Properties = this.GetSomePartsFromProperty();

                return this.View(income);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IEnumerable<PaymentTypeDataModel> GetPaymentType()
        {
            var payments = this.dbContext
                .PaymentTypes
                .Select(x => new PaymentTypeDataModel
                {
                    Id = x.Id,
                    PaymentType = x.Type,
                })
                .ToList();

            return payments;
        }

        public IEnumerable<PropertyTypeDataModel> GetPropertyType()
        {
            var properties = this.dbContext
                .PropertyTypes
                .Select(x => new PropertyTypeDataModel
                {
                    Id = x.Id,
                    PropertyType = x.Type,
                })
                .ToList();
            return properties;
        }

        public IEnumerable<PropertyFloorDataModel> GetPropertyFloor()
        {
            var floors = this.dbContext
                .PropertyFloors
                .Select(x => new PropertyFloorDataModel
                {
                    Id = x.Id,
                    PropertyFloor = x.Floor,
                })
                .ToList();

            return floors;
        }

        public IActionResult PayExpense()
        {
            return this.View(new PayExpenseViewModel
            {
                Expenses = this.GetExpenseType(),
                Payments = this.GetExpensePaymentType(),
            });
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult PayExpense(PayExpenseViewModel expenseType)
        {
            if (!this.ModelState.IsValid)
            {
                expenseType.Expenses = this.GetExpenseType();
                expenseType.Expenses = (IEnumerable<ExpenseTypeDataModel>)this.GetExpensePaymentType();

                return this.View(expenseType);
            }

            // return this.RedirectToAction("Index", "Home");
            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IEnumerable<ExpenseTypeDataModel> GetExpenseType()
        {
            var expenseType = this.dbContext
                .ExpenseTypes
                .Select(x => new ExpenseTypeDataModel
                {
                    Id = x.Id,
                    Type = x.Type,
                })
                .ToList();

            return expenseType;
        }

        public IEnumerable<PaymentTypeDataModel> GetExpensePaymentType()
        {
            var paymentType = this.dbContext
                .PaymentTypes
                .Select(x => new PaymentTypeDataModel
                {
                    Id = x.Id,
                    PaymentType = x.Type,
                })
                .ToList();

            return paymentType;
        }

        public IActionResult ChangeFee()
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
