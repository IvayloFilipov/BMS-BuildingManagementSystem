namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.Expenses.ManagerModules;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;
    using Microsoft.AspNetCore.Mvc;

    public class ManagerController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public ManagerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult AddIncome()
        {
            return this.View(new AddIncomeViewModel
            {
                Payments = this.GetPaymentType(),
                Properties = this.GetPropertyType(),
                Floors = this.GetPropertyTypeFloor(),
            });
        }

        [HttpPost]
        public IActionResult AddIncome(AddIncomeViewModel income)
        {
            if (!this.ModelState.IsValid)
            {
                income.Payments = this.GetPaymentType();
                income.Properties = this.GetPropertyType();
                income.Floors = this.GetPropertyTypeFloor();

                return this.View(income);
            }

            return this.RedirectToAction("Index", "Home");
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

        public IEnumerable<PropertyFloorDataModel> GetPropertyTypeFloor()
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

        [HttpPost]
        public IActionResult PayExpense(PayExpenseViewModel expenseType)
        {
            if (!this.ModelState.IsValid)
            {
                expenseType.Expenses = this.GetExpenseType();
                expenseType.Expenses = (IEnumerable<ExpenseTypeDataModel>)this.GetExpensePaymentType();

                return this.View(expenseType);
            }

            return this.RedirectToAction("Index", "Home");
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
    }
}
