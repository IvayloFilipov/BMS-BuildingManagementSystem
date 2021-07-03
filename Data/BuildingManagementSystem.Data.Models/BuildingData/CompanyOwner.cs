namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    public class CompanyOwner : BaseDeletableModel<int>
    {
        public CompanyOwner()
        {
            this.CompanyProperties = new HashSet<Property>();
        }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        [MaxLength(20)]
        public string UIC { get; set; }

        [Required]
        [MaxLength(150)]
        public string CompanyOwnerFullName { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        // one-to-one with Address - one/every CompanyOwner has only one permanent address
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        // many-to-one with Property - one Company can have/owne many Properties
        public virtual ICollection<Property> CompanyProperties { get; set; }
    }
}
