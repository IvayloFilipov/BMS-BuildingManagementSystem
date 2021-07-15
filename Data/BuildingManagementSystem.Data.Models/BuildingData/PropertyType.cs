namespace BuildingManagementSystem.Data.Models.BuildingData
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class PropertyType
    {
        public PropertyType()
        {
        }

        public PropertyType(string name)
        {
            this.Property = new HashSet<Property>();
        }

        [Key]
        public int Id { get; set; }

        // магазин, апартамент, ателие...
        [Required]
        [MaxLength(PropertyTypeMaxLength)]
        public string Type { get; set; }

        // many-to-one with Property -> many Properties can be one particular Type (Shop/Магазин, Office/Офис, Apartment/Апартамент)
        public virtual ICollection<Property> Property { get; set; }
    }
}
