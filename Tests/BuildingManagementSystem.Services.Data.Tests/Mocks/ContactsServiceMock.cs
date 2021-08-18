namespace BuildingManagementSystem.Services.Data.Tests.Mocks
{
    using BuildingManagementSystem.Data.Models.Common;
    using BuildingManagementSystem.Services.Data.Contacts;
    using Moq;

    public static class ContactsServiceMock
    {
        public static IContactService Instance
        {
            get
            {
                var contactServiceMock = new Mock<IContactService>();

                //contactServiceMock
                //    .Setup(x => x.SendEmail(new ContactForm { }))
                //    .Returns(ContactForm);

                return contactServiceMock.Object;
            }
        }
    }
}
