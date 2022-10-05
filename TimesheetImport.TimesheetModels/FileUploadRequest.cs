using System.IO;

namespace TimesheetImport.TimesheetModels
{
    public class FileUploadRequest
    {
        public int SiteId { get; set; }
       public  MemoryStream File { get; set; }
    }
}
