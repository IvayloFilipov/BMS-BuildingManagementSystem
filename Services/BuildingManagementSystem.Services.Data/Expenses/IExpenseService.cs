﻿namespace BuildingManagementSystem.Services.Data.Expenses
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Expenses.ManagerModules;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;

    public interface IExpenseService
    {
        Task<decimal> PayExpenseAsync(int expenseTypeId, int paymentTypeId, decimal amount, string descrition);

        public IEnumerable<ExpenseTypeDataModel> GetExpenseType();

        public IEnumerable<PaymentTypeDataModel> GetExpensePaymentType();
    }
}
