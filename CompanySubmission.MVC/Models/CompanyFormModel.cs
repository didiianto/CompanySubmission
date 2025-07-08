using System.ComponentModel.DataAnnotations;

namespace CompanySubmission.MVC.Models
{
    public class CompanyFormModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Company Name must be alphanumeric only.")]
        public string CompanyName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "NPWP must be alphanumeric only.")]
        public string NPWP { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Director Name must be alphanumeric only.")]
        public string DirectorName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "PIC Name must be alphanumeric only.")]
        public string PICName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Phone Number must be numeric only.")]
        public string PhoneNumber { get; set; }
        public bool AllowAccessAfterClosing { get; set; }
        public IFormFile NPWPFile { get; set; }
        public IFormFile PowerOfAttorneyFile { get; set; }

        
    }
}
