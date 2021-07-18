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
            var fees = new List<(double Amount, string FeeType)>()
            {
                (ReducedMonthlyFeeAmount, ReducedMonthlyFee),
                (RegularMonthlyAmount, RegularMonthlyFee),
                (IncreasedMonthlyAmount, IncreasedMonthlyFee),
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
