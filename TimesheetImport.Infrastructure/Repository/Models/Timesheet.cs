using System;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class Timesheet
    {
        public int TimeTimesheetId { get; set; }
        public int? TimeCreatedBy { get; set; }
        public DateTime? TimeCreatedDate { get; set; }
        public int? TimeUpdatedBy { get; set; }
        public DateTime? TimeUpdatedDate { get; set; }
        public DateTime? TimeTimeStamp { get; set; }
        public int? TimeDeleted { get; set; }
        public int? TimeSecterr { get; set; }
        public string TimeName { get; set; }
        public int? TimeWorkflowId { get; set; }
        public string TimeStatus { get; set; }
        public int? TimeCompanyId { get; set; }
        public int? TimePersonId { get; set; }
        public int? TimeOpportunityId { get; set; }
        public int? TimeOrderId { get; set; }
        public int? TimeQuoteId { get; set; }
        public int? TimeLeadId { get; set; }
        public int? TimeCaseId { get; set; }
        public int? TimeEmployeeid { get; set; }
        public DateTime? TimeStartdate { get; set; }
        public DateTime? TimeEnddate { get; set; }
        public decimal? TimeNormalhrs { get; set; }
        public decimal? TimeOvertimehrs { get; set; }
        public decimal? TimePhhrs { get; set; }
        public decimal? TimeNightshifthrs { get; set; }
        public decimal? TimeSundayhrs { get; set; }
        public string TimeStage { get; set; }
        public int? TimeSiteid { get; set; }
        public int? TimePrechargesheetid { get; set; }
        public decimal? TimeBreaktimehrs { get; set; }
        public decimal? TimeNormalhrstotal { get; set; }
        public int? TimeNormalhrstotalCid { get; set; }
        public decimal? TimeOvertimehrstotal { get; set; }
        public int? TimeOvertimehrstotalCid { get; set; }
        public int? TimePosition { get; set; }
        public string TimeShift { get; set; }
        public string TimeStarttime { get; set; }
        public string TimeEndtime { get; set; }
        public string TimeApproved { get; set; }
        public string TimePlaceholder1 { get; set; }
        public decimal? TimeNightshifthrstotal { get; set; }
        public int? TimeNightshifthrstotalCid { get; set; }
        public int? TimeEmployeeidsearch { get; set; }
        public int? TimePositionsearch { get; set; }
        public string TimeIncludedweekrun { get; set; }
        public string TimeInvoiced { get; set; }
        public decimal? TimeWorkedhrs { get; set; }
        public DateTime? TimeStartdatesearch { get; set; }
        public DateTime? TimeEnddatesearch { get; set; }
        public string TimeSource { get; set; }
        public int? TimeBatchNo { get; set; }
        public decimal? TimeCalculatedhrs { get; set; }
        public int? TimePayrunid { get; set; }
        public int? TimeWeek { get; set; }
        public int? TimeTimesheetrunid { get; set; }
        public int? TimeInvoiceid { get; set; }
        public decimal? TimeCalcnewtrainhrs { get; set; }
        public int? TimeInvoicerunid { get; set; }
        public string TimeOverride { get; set; }
        public int? TimeNewweek { get; set; }
        public decimal? TimeMondayhrs { get; set; }
        public decimal? TimeTuesdayhrs { get; set; }
        public decimal? TimeWednesdayhrs { get; set; }
        public decimal? TimeThursdayhrs { get; set; }
        public decimal? TimeFridayhrs { get; set; }
        public decimal? TimeSaturdayhrs { get; set; }
    }
}
