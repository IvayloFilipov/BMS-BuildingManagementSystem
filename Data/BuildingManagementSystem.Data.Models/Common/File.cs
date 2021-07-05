namespace BuildingManagementSystem.Data.Models.Common
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class File : BaseDeletableModel<int>
    {
        [Required]
        public string DocumentName { get; set; }

        [Required]
        [MaxLength(URLMaxLength)]
        public string URL { get; set; }

        [Required]
        [MaxLength(FileDescriptionMaxLength)]
        public string Descrtiption { get; set; }

        [Required]
        [MaxLength(FileExtensionMaxLength)]
        public string Extension { get; set; }

        // The contents of the files is in the file system
    }
}
