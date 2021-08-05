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

        public async Task<int> AddAddressAsync(int cityId, string district, int zipCode, string street, string streetNumber, string blockNumber, string entranceNumber, string floor, string appartNumber)
        {
            // var city = this.dbContext.Cities.Select(x => x.Id == cityId);
            var address = new Address()
            {
                CityId = cityId,
                District = district,
                ZipCode = zipCode,
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
