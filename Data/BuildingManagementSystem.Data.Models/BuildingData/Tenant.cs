namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    public class Tenant : BaseDeletableModel<int>
    {
        public Tenant()
        {
            this.TenantProperties = new HashSet<Property>();
        }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Phone { get; set; }

        // many-to-one with Property - many Properties can be hired by one Tenant
        public virtual ICollection<Property> TenantProperties { get; set; }
    }
}
