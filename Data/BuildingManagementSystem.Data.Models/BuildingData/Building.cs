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
        }

        [Key]
        public int Id { get; set; }

        // one-to-one with Address - one building has only one address
        public virtual Address Address { get; set; }

        // many-to-one with Account
        public virtual ICollection<Account> Accounts { get; set; }

        // many-to-one with Property - one Building has many Properties
        public virtual ICollection<Property> Properties { get; set; }
    }
}
