namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        public City()
        {
            this.Addresses = new HashSet<Address>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        // many-to-one with Address - many addresses can be in one city
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
