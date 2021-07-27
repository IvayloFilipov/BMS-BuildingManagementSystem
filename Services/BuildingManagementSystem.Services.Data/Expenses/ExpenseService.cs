namespace BuildingManagementSystem.Services.Data.Expenses
{
    using System;

    using BuildingManagementSystem.Data;

    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext dbContext;

        public ExpenseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void PayExpense()
        {
            throw new NotImplementedException();
        }
    }
}
