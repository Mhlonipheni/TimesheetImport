namespace TimesheetImportAPI.Models
{
    public class FileUploadRequest
    { 

        public int SiteId { get; set; }
        public IFormCollection? FormCollection { get; set; } 
    }
}
