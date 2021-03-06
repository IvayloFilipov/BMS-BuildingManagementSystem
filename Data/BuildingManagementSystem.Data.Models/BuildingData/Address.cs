namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class Address : BaseDeletableModel<int>
    {
        // one-to-many with City
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [MaxLength(DistrictMaxLength)]
        public string District { get; set; }

        [MaxLength(StreetMaxLength)]
        public string Street { get; set; }

        [MaxLength(StreetNumberMaxLength)]
        public string StreetNumber { get; set; }

        [MaxLength(BlockNumberMaxLength)]
        public string BlockNumber { get; set; }

        [MaxLength(EntranceNumberMaxLength)]
        public string EntranceNumber { get; set; }

        public string Floor { get; set; }

        public string AppartNumber { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        // one-to-many with Building
        public int BuildingId { get; set; }

        public virtual Building Building { get; set; }

        // one-to-one with Owner
        public virtual Owner Owner { get; set; }

        // one-to-one with CompanyOwner
        public virtual CompanyOwner CompanyOwner { get; set; }
    }
}
