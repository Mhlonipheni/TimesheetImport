using System;
using System.Collections.Generic;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class Rate
    {
        public int RateRateId { get; set; }
        public int? RateCreatedBy { get; set; }
        public DateTime? RateCreatedDate { get; set; }
        public int? RateUpdatedBy { get; set; }
        public DateTime? RateUpdatedDate { get; set; }
        public DateTime? RateTimeStamp { get; set; }
        public int? RateDeleted { get; set; }
        public int? RateSecterr { get; set; }
        public string RateName { get; set; }
        public int? RateWorkflowId { get; set; }
        public string RateStatus { get; set; }
        public int? RateCompanyId { get; set; }
        public decimal? RateOvertimerate { get; set; }
        public int? RateOvertimerateCid { get; set; }
        public decimal? RateNormalrate { get; set; }
        public int? RateNormalrateCid { get; set; }
        public decimal? RateSundayrate { get; set; }
        public int? RateSundayrateCid { get; set; }
        public decimal? RatePublicholidayrate { get; set; }
        public int? RatePublicholidayrateCid { get; set; }
        public int? RateEmployeeid { get; set; }
        public decimal? RateNightshiftrate { get; set; }
        public int? RateNightshiftrateCid { get; set; }
        public int? RateSiteid { get; set; }
        public DateTime? RateEffectivedate { get; set; }
        public decimal? RateFixedrate { get; set; }
        public int? RateFixedrateCid { get; set; }
        public int? RatePosition { get; set; }
        public decimal? RateNormalrateperc { get; set; }
        public decimal? RateOvertimerateperc { get; set; }
        public decimal? RateSundayrateperc { get; set; }
        public decimal? RatePublicholidatereateperc { get; set; }
        public decimal? RateNightshiftrateperc { get; set; }
        public string RateNightshift { get; set; }
        public decimal? RateManagementfee { get; set; }
        public int? RateManagementfeeCid { get; set; }
        public string RateType { get; set; }
        public string RateShift { get; set; }
        public string RateApplynightshift { get; set; }
        public string RatePayovertime { get; set; }
        public decimal? RateFullshiftvalue { get; set; }
        public int? RateFullshiftvalueCid { get; set; }
        public string RateProforma { get; set; }
        public string RateInvoicingfrequency { get; set; }
        public string RateInvoicinggrouping { get; set; }
        public string RateLinkedtohrsworked { get; set; }
        public DateTime? RateEnddate { get; set; }
        public decimal? RatePayrate { get; set; }
        public int? RatePayrateCid { get; set; }
    }
}
