namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class Owner : BaseDeletableModel<int>
    {
        public Owner()
        {
            this.Properties = new HashSet<PropertyOwner>();
        }

        [Required]
        [MaxLength(OwnerFirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(OwnerMiddleNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(OwnerLastNameMaxLength)]
        public string LastName { get; set; }

        [MaxLength(OwnerEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(OwnerPhoneMaxLength)]
        public string Phone { get; set; }

        // many-to-many with Property - make class PropertyOwner
        public virtual ICollection<PropertyOwner> Properties { get; set; }

        // one-to-one with Address - every Owner has only one permanent address
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
