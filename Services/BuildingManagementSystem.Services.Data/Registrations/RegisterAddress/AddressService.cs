namespace BuildingManagementSystem.Services.Data.Registrations.RegisterAddress
{
    using System;

    using BuildingManagementSystem.Data;

    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext dbContext;

        public AddressService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RegisterAddress()
        {
            throw new NotImplementedException();
        }
    }
}
