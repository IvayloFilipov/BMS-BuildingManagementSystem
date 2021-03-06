namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class Tenant : BaseDeletableModel<int>
    {
        public Tenant()
        {
            this.TenantProperties = new HashSet<Property>();
        }

        [Required]
        [MaxLength(TenantFirstNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(TenantMiddleNameMaxLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(TenantLastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(TenantEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(TenantPhoneMaxLength)]
        public string Phone { get; set; }

        // many-to-one with Property - many Properties can be hired by one Tenant
        public virtual ICollection<Property> TenantProperties { get; set; }

        // Това е Id-то регистрирания собственик като string, на който си наемател и те е регистрирал в приложението след като се е логнал.
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        // Това е Id-то на собственика като int, на който си наемател и те е регистрирал в приложението.
        public int? OwnerId { get; set; }

        public Owner Owner { get; set; }

        // Това е Id-то на фирмата собственик като int, на която си наемател и те е регистрирала в приложението.
        public int? CompanyOwnerId { get; set; }

        public CompanyOwner CompanyOwner { get; set; }

        public bool IsConfirmed { get; set; }
    }
}
