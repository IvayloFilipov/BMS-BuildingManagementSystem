namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Models.BuildingFunds;

    public class Building
    {
        public Building()
        {
            this.Properties = new HashSet<Property>();
            this.Accounts = new HashSet<Account>();
            this.Addresses = new HashSet<Address>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(35)]
        public string Name { get; set; }

        // one-to-many with Address - one building has many addresses
        public virtual ICollection<Address> Addresses { get; set; }

        // many-to-one with Account
        public virtual ICollection<Account> Accounts { get; set; }

        // many-to-one with Property - one Building has many Properties
        public virtual ICollection<Property> Properties { get; set; }
    }
}
