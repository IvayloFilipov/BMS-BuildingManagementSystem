namespace BuildingManagementSystem.Services.Data.Incomes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.Incomes.ManagerModules;

    public class IncomeService : IIncomeService
    {
        private readonly ApplicationDbContext dbContext;

        public IncomeService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<decimal> AddIncomeAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddToAccountAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentTypeDataModel> GetPaymentType()
        {
            var payments = this.dbContext
                .PaymentTypes
                .Select(x => new PaymentTypeDataModel
                {
                    Id = x.Id,
                    PaymentType = x.Type,
                })
                .ToList();

            return payments;
        }

        public IEnumerable<PropertyFloorDataModel> GetPropertyFloor()
        {
            var floors = this.dbContext
                   .PropertyFloors
                   .Select(x => new PropertyFloorDataModel
                   {
                       Id = x.Id,
                       PropertyFloor = x.Floor,
                   })
                   .ToList();

            return floors;
        }

        public IEnumerable<PropertyTypeDataModel> GetPropertyType()
        {
            var properties = this.dbContext
                   .PropertyTypes
                   .Select(x => new PropertyTypeDataModel
                   {
                       Id = x.Id,
                       PropertyType = x.Type,
                   })
                   .ToList();
            return properties;
        }
    }
}
