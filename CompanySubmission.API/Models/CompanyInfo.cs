namespace CompanySubmission.API.Models
{
    public class CompanyInfo
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string NPWP { get; set; }
        public string DirectorName { get; set; }
        public string PICName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool AllowAccessAfterClosing { get; set; }
        public string? NPWPFilePath { get; set; } = string.Empty;
        public string? PowerOfAttorneyFilePath { get; set; } = string.Empty;
        
    }
}
