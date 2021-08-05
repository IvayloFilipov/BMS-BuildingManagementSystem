namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.ComponentModel.DataAnnotations;

    public class PropertyOwner
    {
        [Key]
        public int Id { get; set; }

        // many-to-many -> mapping between Owner and Property - One Owner can owne many properties. One property can be owen by many owners.
        public int OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
