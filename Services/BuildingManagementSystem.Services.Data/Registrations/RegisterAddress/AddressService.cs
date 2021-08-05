namespace BuildingManagementSystem.Services.Data.Registrations.RegisterAddress
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.Registrations;

    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext dbContext;

        public AddressService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddAddressAsync(int cityId, string district, string street, string streetNumber, string blockNumber, string entranceNumber, string floor, string appartNumber)
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
            };

            await this.dbContext.Addresses.AddAsync(address);

            await this.dbContext.SaveChangesAsync();

            return address.Id;
        }

        public IEnumerable<AllCitiesDataModel> GetAllCities()
        {
            var cities = this.dbContext
                .Cities
                .Select(x => new AllCitiesDataModel
                {
                    Id = x.Id,
                    City = x.Name,
                })
                .ToList();

            return cities;
        }
    }
}
