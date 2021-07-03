namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PropertyFloor
    {
        public PropertyFloor()
        {
            this.Property = new HashSet<Property>();
        }

        [Key]
        public int Id { get; set; }

        // (Подземни гаражи, Партер, 1, 2 ...)
        [Required]
        public byte Floor { get; set; }

        // many-to-one with Property -> many Properties can lay on a Floor
        public virtual ICollection<Property> Property { get; set; }
    }
}
