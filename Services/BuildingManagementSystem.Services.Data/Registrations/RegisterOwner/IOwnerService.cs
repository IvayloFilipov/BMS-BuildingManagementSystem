namespace BuildingManagementSystem.Services.Data.Registrations.RegisterOwner
{
    using System.Threading.Tasks;

    public interface IOwnerService
    {
        Task<int> AddOwnerAsync(string firstName, string middleName, string lastName, string email, string phone);
    }
}
