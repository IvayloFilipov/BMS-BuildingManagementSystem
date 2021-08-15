namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingFunds;

    using static BuildingManagementSystem.Common.GlobalConstants;

    internal class BuildingAccountsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var accounts = new List<string>
            {
                CashAccounType,
                UbbBankAccountType,
            };

            var newAccountsList = new List<Account>();

            foreach (var currAccount in accounts)
            {
                if (!dbContext.BuildingAccounts.Any(x => x.AccountType == currAccount))
                {
                    var newAccount = new Account()
                    {
                        AccountType = currAccount,
                    };

                    newAccountsList.Add(newAccount);
                }
            }

            // var dbAccounts = await dbContext.BuildingAccounts.Select(x => x.AccountType).ToListAsync();

            // var newAccounts = accounts
            //    .Where(currAccount => !dbAccounts.Contains(currAccount))
            //    .Select(currAccount => new Account { AccountType = currAccount })
            //    .ToList();
            if (!newAccountsList.Any())
            {
                return;
            }

            await dbContext.BuildingAccounts.AddRangeAsync(newAccountsList);

            await dbContext.SaveChangesAsync();
        }
    }
}
