namespace BuildingManagementSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using BuildingManagementSystem.Common;
    using BuildingManagementSystem.Data.Models.Common;
    using BuildingManagementSystem.Services.Data.Contacts;
    using BuildingManagementSystem.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : BaseController
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
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

            await this.contactService.SendEmail(contactFormEntry);

            this.TempData[GlobalConstants.RedirectedFromContactForm] = true;

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            if (this.TempData[GlobalConstants.RedirectedFromContactForm] == null)
            {
                return this.NotFound();
            }

            return this.View();
        }
    }
}
