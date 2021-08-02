namespace BuildingManagementSystem.Web.ViewModels.ManagerModules.Documents
{
    using System.ComponentModel.DataAnnotations;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class UploadDocumentViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете името на документа")]
        [StringLength(100, ErrorMessage = DistrictNameErrorMessage, MinimumLength = 10)]
        [Display(Name = "Име на документа")]
        public string DocumentName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете URL")]
        [MaxLength(URLMaxLength)]
        [Display(Name = "URL")]
        public string URL { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете кратко описание")]
        [StringLength(FileDescriptionMaxLength, ErrorMessage = DistrictNameErrorMessage, MinimumLength = 10)]
        [Display(Name = "Описание")]
        public string Descrtiption { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете данни за типа на документа")]
        [StringLength(FileExtensionMaxLength, ErrorMessage = DistrictNameErrorMessage, MinimumLength = 3)]
        [Display(Name = "Тип на документа (.xlsx, .docx, .pdf, .jpeg, ...)")]
        public string Extension { get; set; }
    }
}
