namespace BuildingManagementSystem.Services.Data.Debts
{
    using System;

    using BuildingManagementSystem.Data;

    public class FeeService : IFeeService
    {
        private readonly ApplicationDbContext dbContext;

        public FeeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void ChangeFee()
        {
            throw new NotImplementedException();
        }
    }
}
