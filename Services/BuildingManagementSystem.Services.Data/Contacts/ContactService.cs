namespace BuildingManagementSystem.Services.Data.Contacts
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.Common;
    using BuildingManagementSystem.Services.Messaging;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IEmailSender emailSender;

        public ContactService(ApplicationDbContext dbContext, IEmailSender emailSender)
        {
            this.dbContext = dbContext;
            this.emailSender = emailSender;
        }

        public async Task SendEmail(ContactForm contactForm)
        {
            await this.dbContext.ContactForms.AddAsync(contactForm);
            await this.dbContext.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                contactForm.Email,
                contactForm.FullName,
                SystemEmail,
                contactForm.Title,
                contactForm.Content);
        }
    }
}
