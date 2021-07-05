namespace BuildingManagementSystem.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class ContactForm
    {
        [Key]
        public int Id { get; set; }

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

        public string Ip { get; set; }

        public bool Readed { get; set; }
    }
}
