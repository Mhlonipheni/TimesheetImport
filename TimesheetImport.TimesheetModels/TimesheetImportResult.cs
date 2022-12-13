using System.Collections.Generic;

namespace TimesheetImport.TimesheetModels
{
    public class TimesheetImportResult
    {
        public bool Success { get; set; }
        public List<Notification> Notifications { get; set; } = new List<Notification>();
    }
    public class Notification
    {
        public string LineNumber { get; set; }
        public string Message { get; set; }
    }
}
