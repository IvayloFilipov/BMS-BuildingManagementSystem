namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.Debts;

    using static BuildingManagementSystem.Common.GlobalConstants;

    internal class MonthlyFeesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var description = "По решение на ОС от 15,10,2020 год.";

            var fees = new List<(double Amount, string FeeType, string Description)>()
            {
                (ReducedMonthlyFeeAmount, ReducedMonthlyFee, description),
                (RegularMonthlyAmount, RegularMonthlyFee, description),
                (IncreasedMonthlyAmount, IncreasedMonthlyFee, description),
            };

            var newFeesList = new List<Fee>();

            foreach (var currFee in fees)
            {
                if (!dbContext.Fees.Any(x => x.Type == currFee.FeeType))
                {
                    var newFee = new Fee()
                    {
                        Type = currFee.FeeType,
                        Amount = currFee.Amount,
                        Description = description,
                    };

                    newFeesList.Add(newFee);
                }
            }

            if (!newFeesList.Any())
            {
                return;
            }

            await dbContext.Fees.AddRangeAsync(newFeesList);

            await dbContext.SaveChangesAsync();
        }
    }
}
