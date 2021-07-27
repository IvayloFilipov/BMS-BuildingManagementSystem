namespace BuildingManagementSystem.Services.Data.Registrations.RegisterCompanyOwner
{
    using System;

    using BuildingManagementSystem.Data;

    public class CompanyOwnerService : ICompanyOwnerService
    {
        private readonly ApplicationDbContext dbContext;

        public CompanyOwnerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RegisterCompany()
        {
            throw new NotImplementedException();
        }
    }
}
