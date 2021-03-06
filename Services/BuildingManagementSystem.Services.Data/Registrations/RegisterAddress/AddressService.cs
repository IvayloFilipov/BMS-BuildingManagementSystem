namespace BuildingManagementSystem.Services.Data.Registrations.RegisterAddress
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.Registrations;
    using Microsoft.EntityFrameworkCore;

    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext dbContext;

        public AddressService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddAddressAsync(int cityId, string district, string street, string streetNumber, string blockNumber, string entranceNumber, string floor, string appartNumber, string userId)
        {
            var selectedCityID = this.dbContext
                .Cities
                .Where(x => x.Id == cityId)
                .Select(x => x.Id)
                .FirstOrDefault();

            var selectedBuildingId = this.dbContext
                .Building
                .Select(x => x.Id)
                .FirstOrDefault();

            var address = new Address()
            {
                CityId = selectedCityID,
                BuildingId = selectedBuildingId,
                District = district,
                Street = street,
                StreetNumber = streetNumber,
                BlockNumber = blockNumber,
                EntranceNumber = entranceNumber,
                Floor = floor,
                AppartNumber = appartNumber,
                UserId = userId,
            };

            await this.dbContext.Addresses.AddAsync(address);

            await this.dbContext.SaveChangesAsync();

            return address.Id;
        }

        public async Task<IEnumerable<AllCitiesDataModel>> GetAllCitiesAsync()
        {
            var cities = await this.dbContext
                .Cities
                .Select(x => new AllCitiesDataModel
                {
                    Id = x.Id,
                    City = x.Name,
                })
                .ToListAsync();

            return cities;
        }
    }
}
