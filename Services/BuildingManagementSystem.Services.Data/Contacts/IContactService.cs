namespace BuildingManagementSystem.Services.Data.Contacts
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models.Common;

    public interface IContactService
    {
        public Task SendEmail(ContactForm contactForm);
    }
}
