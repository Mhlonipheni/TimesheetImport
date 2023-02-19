using System;
using System.Collections.Generic;

namespace TimesheetImport.TimesheetModels
{
    public class TimesheetImportConfirmationResult
    {
        public bool Success { get; set; }
        public List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
