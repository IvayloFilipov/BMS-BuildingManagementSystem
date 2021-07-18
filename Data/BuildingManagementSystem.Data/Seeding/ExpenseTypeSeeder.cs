namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingExpenses;

    using static BuildingManagementSystem.Common.GlobalConstants;

    internal class ExpenseTypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var expenses = new List<string>()
            {
                ElectriciyElevatorExpenseType,
                MaintenanceElevatorFeeExpenseType,
                StairsElectriciyStairsExpenseType,
                BankFeeExpenseType,
                ManagementFeeExpenseType,
                CleaningFeeExpenseType,
                OthersExpenseType,
            };

            var newExpensesList = new List<ExpenseType>();

            foreach (var currExpense in expenses)
            {
                if (!dbContext.ExpenseTypes.Any(x => x.Type == currExpense))
                {
                    var newEspense = new ExpenseType()
                    {
                        Type = currExpense,
                    };

                    newExpensesList.Add(newEspense);
                }
            }

            if (!newExpensesList.Any())
            {
                return;
            }

            await dbContext.ExpenseTypes.AddRangeAsync(newExpensesList);

            await dbContext.SaveChangesAsync();
        }
    }
}
