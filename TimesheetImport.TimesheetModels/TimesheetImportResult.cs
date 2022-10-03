﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
