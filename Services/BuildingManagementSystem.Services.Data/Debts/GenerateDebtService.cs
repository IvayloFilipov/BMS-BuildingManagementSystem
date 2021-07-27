namespace BuildingManagementSystem.Services.Data.Debts
{
    using System;

    using BuildingManagementSystem.Data;

    public class GenerateDebtService : IGenerateDebtService
    {
        private readonly ApplicationDbContext dbContext;

        public GenerateDebtService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GenerateDebt()
        {
            throw new NotImplementedException();
        }
    }
}
