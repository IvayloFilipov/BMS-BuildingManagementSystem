namespace BuildingManagementSystem.Services.Data.Registrations.RegisterAddress
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Web.ViewModels.Registrations;

    public interface IAddressService
    {
        Task<int> AddAddressAsync(int cityId, string district, string street, string streetNumber, string blockNumber, string entranceNumber, string floor, string appartNumber, string userId);

        Task<IEnumerable<AllCitiesDataModel>> GetAllCitiesAsync();
    }
}
