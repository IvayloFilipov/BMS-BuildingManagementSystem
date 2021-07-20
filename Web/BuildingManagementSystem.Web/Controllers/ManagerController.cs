namespace BuildingManagementSystem.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Web.ViewModels.ManagerModules;
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
                Properties = this.GetProperties(),
            });
        }

        [HttpPost]
        public IActionResult AddIncome(AddIncomeViewModel income)
        {
            if (!this.ModelState.IsValid)
            {
                income.Payments = this.GetPaymentType();
                income.Properties = this.GetProperties();

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

        public IEnumerable<PropertyDataModel> GetProperties()
        {
            var properties = this.dbContext
                .Properties
                .Select(x => new PropertyDataModel
                {
                    Id = x.Id,
                    PropertyType = x.PropertyType.Type,
                    PropertyFloor = x.PropertyFloor.Floor,
                    PropertyNumber = x.Number.ToString(),
                })
                .ToList();

            return properties;
        }

        public IActionResult PayExpense()
        {
            return this.View();
        }

        public IActionResult ChangeFee()
        {
            return this.View();
        }
    }
}
