namespace TimesheetImportAPI.Models
{
    public class FileUploadRequest
    { 

        public string SiteId { get; set; }
        public IFormCollection? FormCollection { get; set; } 
    }
}
