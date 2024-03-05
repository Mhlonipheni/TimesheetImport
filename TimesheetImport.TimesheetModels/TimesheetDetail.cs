using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetImport.TimesheetModels
{
    public class TimesheetDetail
    {
        public int? TimeCreatedBy { get; set; }
        public DateTime? TimeCreatedDate { get; set; }
        public int? TimeUpdatedBy { get; set; }
        public DateTime? TimeUpdatedDate { get; set; }
        public DateTime? TimeTimeStamp { get; set; }
        public int? TimeSecterr { get; set; }
        public string TimeStatus { get; set; }
        public int? TimeCompanyId { get; set; }
        public int? TimeEmployeeid { get; set; }
        public DateTime? TimeStartdate { get; set; }
        public DateTime? TimeEnddate { get; set; }
        public decimal? TimeNormalhrs { get; set; }
        public decimal? TimeOvertimehrs { get; set; }
        public decimal? TimeNightshifthrs { get; set; }
        public decimal? TimeSundayhrs { get; set; }
        public int? TimeSiteid { get; set; }
        public decimal? TimeBreaktimehrs { get; set; }
        public int? TimePosition { get; set; }
        public string TimeShift { get; set; }
        public string TimeStarttime { get; set; }
        public string TimeEndtime { get; set; }
        public decimal? TimeWorkedhrs { get; set; }
        public string TimeSource { get; set; }
        public int? TimeBatchNo { get; set; }
        public int? TimeWeek { get; set; }
        public int? TimeTimesheetrunid { get; set; }
        public int? TimeNewweek { get; set; }
        public decimal? TimePhhrs { get; set; }
        public string TimeApproved { get; set; }
    }
}
