using System;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class TimesheetRun
    {
        public int TimhTimesheetRunId { get; set; }
        public int? TimhCreatedBy { get; set; }
        public DateTime? TimhCreatedDate { get; set; }
        public int? TimhUpdatedBy { get; set; }
        public DateTime? TimhUpdatedDate { get; set; }
        public DateTime? TimhTimeStamp { get; set; }
        public int? TimhDeleted { get; set; }
        public int? TimhSecterr { get; set; }
        public string TimhName { get; set; }
        public int? TimhWorkflowId { get; set; }
        public string TimhStatus { get; set; }
        public int? TimhUserId { get; set; }
        public int? TimhChannelId { get; set; }
        public DateTime? TimhDate { get; set; }
        public int? TimhSiteid { get; set; }
        public int? TimhRosterid { get; set; }
        public string TimhStage { get; set; }
        public string TimhTimesheetscreated { get; set; }
        public string TimhShift { get; set; }
    }
}
