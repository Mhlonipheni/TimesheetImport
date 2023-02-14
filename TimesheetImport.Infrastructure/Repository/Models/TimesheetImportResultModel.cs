using System.Collections.Generic;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public class TimesheetImportResultModel
    {
        public bool Success { get; set; }
        public List<Notification> Notifications { get; set; }
    }

    public class Notification
    {
        public string Id { get; set; }
        public string LineNumber { get; set; }
        public string ErrorMessage { get; set; }    
    }
}
