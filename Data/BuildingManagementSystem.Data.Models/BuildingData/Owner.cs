namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    public class Owner : BaseDeletableModel<int>
    {
        public Owner()
        {
            this.Properties = new HashSet<PropertyOwner>();
        }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        // many-to-many with Property - make class PropertyOwner
        public virtual ICollection<PropertyOwner> Properties { get; set; }

        // one-to-one with Address - every Owner has only one permanent address
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
