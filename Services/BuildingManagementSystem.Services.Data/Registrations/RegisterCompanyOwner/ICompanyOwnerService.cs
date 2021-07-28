namespace BuildingManagementSystem.Services.Data.Registrations.RegisterCompanyOwner
{
    using System.Threading.Tasks;

    public interface ICompanyOwnerService
    {
        Task<int> AddCompanyOwnerAsync(string companyName, string uic, string companyOwnerFirstName, string companyOwnerLastName, string email, string phone);
    }
}
