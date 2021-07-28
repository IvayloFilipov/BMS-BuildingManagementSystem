namespace BuildingManagementSystem.Services.Data.Registrations.RegisterAddress
{
    using System.Threading.Tasks;

    public interface IAddressService
    {
        Task<int> AddAddressAsync(int cityId, string district, int zipCode, string street, string streetNumber, string blockNumber, string entranceNumber, string floor, string appartNumber);
    }
}
