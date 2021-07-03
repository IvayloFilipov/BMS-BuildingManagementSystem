namespace BuildingManagementSystem.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    public class ContactForm
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(15000)]
        public string Content { get; set; }

        public string Ip { get; set; }

        public bool Readed { get; set; }
    }
}
