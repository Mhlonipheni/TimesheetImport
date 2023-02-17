using System.Collections.Generic;
using System.Linq;

namespace TimesheetImport.TimesheetModels
{
    public class TimesheetImportResult
    {
        public List<TimesheetDetail> TimesheetDetails { get; set; } = new List<TimesheetDetail>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();
        public List<Notification> Errors => Notifications.Where(n => n.Severity == Severity.Critical).ToList();
        public List<Notification> Warnings => Notifications.Where(n => n.Severity == Severity.Warning).ToList();
        public bool HasErrors => Notifications.Any(n => n.Severity == Severity.Critical);
        public bool HasWarnings => Notifications.Any(n => n.Severity == Severity.Warning);
        public bool HasInformation => Notifications.Any(n => n.Severity == Severity.Information);
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
