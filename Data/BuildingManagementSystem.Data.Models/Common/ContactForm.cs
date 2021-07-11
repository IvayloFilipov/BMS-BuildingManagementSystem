namespace BuildingManagementSystem.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ContactForm : BaseModel<int>
    {
        [Required]
        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(ContactEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(ContactPhoneMaxLength)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(ContactTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContactContentMaxLength)]
        public string Content { get; set; }
    }
}
