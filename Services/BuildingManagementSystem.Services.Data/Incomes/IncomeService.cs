namespace BuildingManagementSystem.Services.Data.Incomes
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;

    public class IncomeService : IIncomeService
    {
        private readonly ApplicationDbContext dbContext;

        public IncomeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddIncomeAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            throw new NotImplementedException();
        }
    }
}
