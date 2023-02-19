namespace TimesheetImportAPI.Models
{
    public class TimesheetImportResult1
    {
        public bool Success { get; set; }
        public List<Notification> Notifications { get; set; } = new List<Notification>();
    }
    public class Notification
    {
        public string LineNumber { get; set; }
        public string Message { get; set; }
        public Severity Severity { get; set; }

    }

    public enum Severity
    {
        Critical,
        Warning,
        Information
    }
}
