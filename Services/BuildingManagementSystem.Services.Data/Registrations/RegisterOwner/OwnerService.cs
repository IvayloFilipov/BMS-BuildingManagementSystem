namespace BuildingManagementSystem.Services.Data.Registrations.RegisterOwner
{
    using System;

    using BuildingManagementSystem.Data;

    public class OwnerService : IOwnerService
    {
        private readonly ApplicationDbContext dbContext;

        public OwnerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RegisterPerson()
        {
            throw new NotImplementedException();
        }
    }
}
