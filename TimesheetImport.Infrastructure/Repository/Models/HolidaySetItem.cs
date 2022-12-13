using System;
using System.Collections.Generic;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class HolidaySetItem
    {
        public int HsitCalendarId { get; set; }

        public int? HsitCreatedBy { get; set; }

        public DateTime? HsitCreatedDate { get; set; }

        public int? HsitUpdatedBy { get; set; }

        public DateTime? HsitUpdatedDate { get; set; }

        public DateTime? HsitTimeStamp { get; set; }

        public int? HsitDeleted { get; set; }

        public int? HsitHsetHolidaySetId { get; set; }

        public string HsitHolidayName { get; set; }

        public DateTime? HsitHolidayDate { get; set; }
    }
}