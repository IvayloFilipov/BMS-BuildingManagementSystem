namespace BuildingManagementSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.BuildingIncomes;

    using static BuildingManagementSystem.Common.GlobalConstants;

    internal class PaymentTypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var payments = new List<string>()
            {
                CashPaymentType,
                BankPaymentType,
            };

            var newPayments = new List<PaymentType>();

            foreach (var currPayment in payments)
            {
                if (!dbContext.PaymentTypes.Any(x => x.Type == currPayment))
                {
                    var newPayment = new PaymentType()
                    {
                        Type = currPayment,
                    };

                    newPayments.Add(newPayment);
                }
            }

            if (!newPayments.Any())
            {
                return;
            }

            await dbContext.PaymentTypes.AddRangeAsync(newPayments);

            await dbContext.SaveChangesAsync();
        }
    }
}
