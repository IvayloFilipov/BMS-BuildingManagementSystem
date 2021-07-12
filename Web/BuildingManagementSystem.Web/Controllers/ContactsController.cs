namespace BuildingManagementSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Common;
    using BuildingManagementSystem.Data.Common.Repositories;
    using BuildingManagementSystem.Data.Models.Common;
    using BuildingManagementSystem.Services.Messaging;
    using BuildingManagementSystem.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : BaseController
    {
        private const string RedirectedFromContactForm = "RedirectedFromContactForm";

        private readonly IRepository<ContactForm> contactsRepository;

        private readonly IEmailSender emailSender;

        public ContactsController(IRepository<ContactForm> contactsRepository, IEmailSender emailSender)
        {
            this.contactsRepository = contactsRepository;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel contact)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(contact);
            }

            var contactFormEntry = new ContactForm
            {
                FullName = contact.FullName,
                Email = contact.Email,
                Phone = contact.Phone,
                Title = contact.Title,
                Content = contact.Content,
            };

            await this.contactsRepository.AddAsync(contactFormEntry);
            await this.contactsRepository.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                contact.Email,
                contact.FullName,
                GlobalConstants.SystemEmail,
                contact.Title,
                contact.Content);

            this.TempData[RedirectedFromContactForm] = true;

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            if (this.TempData[RedirectedFromContactForm] == null)
            {
                return this.NotFound();
            }

            return this.View();
        }
    }
}
