namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class CompanyOwner : BaseDeletableModel<int>
    {
        public CompanyOwner()
        {
            this.CompanyProperties = new HashSet<Property>();
            this.Tenants = new HashSet<Tenant>();
        }

        [Required]
        [MaxLength(CompanyNameMaxLength)]
        public string CompanyName { get; set; }

        [MaxLength(UICMaxLength)]
        public string UIC { get; set; }

        [Required]
        [MaxLength(CompanyOwnerFirstNameMaxLength)]
        public string CompanyOwnerFirstName { get; set; }

        [Required]
        [MaxLength(CompanyOwnerLastNameMaxLength)]
        public string CompanyOwnerLastName { get; set; }

        [Required]
        [MaxLength(CompanyEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(CompanyPhoneMaxLength)]
        public string Phone { get; set; }

        // one-to-one with Address - one/every CompanyOwner has only one permanent address
        public int? AddressId { get; set; }

        public virtual Address Address { get; set; }

        // many-to-one with Property - one Company can have/owne many Properties
        public virtual ICollection<Property> CompanyProperties { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<Tenant> Tenants { get; set; }
    }
}
