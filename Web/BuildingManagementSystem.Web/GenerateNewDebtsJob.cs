namespace BuildingManagementSystem.Web
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.Debts;
    using Hangfire;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class GenerateNewDebtsJob
    {
        private readonly ApplicationDbContext dbContext;

        public GenerateNewDebtsJob(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [AutomaticRetry(Attempts = 2)]
        public async Task Work()
        {
            var properties = this.dbContext.Properties.ToArray();

            var fees = this.dbContext.Fees.ToArray();

            var allDebts = new List<PropertyDebt>();

            foreach (var property in properties)
            {
                var monthlyDebt = new PropertyDebt
                {
                    PropertyId = property.Id,
                    Descrtiption = "Месечна такса",
                };

                switch (property.StatusId)
                {
                    case 1:
                        monthlyDebt.FeeId = fees.First(x => x.Type == ReducedMonthlyFee).Id;
                        break;
                    case 2:
                        monthlyDebt.FeeId = fees.First(x => x.Type == RegularMonthlyFee).Id;
                        break;
                    case 3:
                        monthlyDebt.FeeId = fees.First(x => x.Type == RegularMonthlyFee).Id;
                        break;
                    case 4:
                        monthlyDebt.FeeId = fees.First(x => x.Type == IncreasedMonthlyFee).Id;
                        break;
                }

                allDebts.Add(monthlyDebt);
            }

            await this.dbContext.PropertyDebtsMonthly.AddRangeAsync(allDebts);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
