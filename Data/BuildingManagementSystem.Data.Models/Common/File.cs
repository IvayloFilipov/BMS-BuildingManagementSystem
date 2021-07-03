namespace BuildingManagementSystem.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    public class File : BaseDeletableModel<int>
    {
        [Required]
        public string DocumentName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string URL { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descrtiption { get; set; }

        [Required]
        [MaxLength(10)]
        public string Extension { get; set; }

        // The contents of the files is in the file system
    }
}
