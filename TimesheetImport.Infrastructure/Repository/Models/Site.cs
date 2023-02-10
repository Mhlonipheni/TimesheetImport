using System;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class Site
    {
        public int SiteSiteId { get; set; }
        public int? SiteCreatedBy { get; set; }
        public DateTime? SiteCreatedDate { get; set; }
        public int? SiteUpdatedBy { get; set; }
        public DateTime? SiteUpdatedDate { get; set; }
        public DateTime? SiteTimeStamp { get; set; }
        public int? SiteDeleted { get; set; }
        public int? SiteSecterr { get; set; }
        public string SiteName { get; set; }
        public string SiteStatus { get; set; }
        public int? SiteCompanyId { get; set; }
        public string SiteProjectnumber { get; set; }
        public string SitePhonenumber { get; set; }
        public string SiteEmailaddress { get; set; }
        public string SiteContactname { get; set; }
        public string SiteAddress1 { get; set; }
        public string SiteAddress2 { get; set; }
        public string SiteCity { get; set; }
        public string SitePostcode { get; set; }
        public string SiteCountry { get; set; }
        public string SiteState { get; set; }
        public int? SiteStarttime { get; set; }
        public int? SiteEndtime { get; set; }
        public string SiteShift { get; set; }
        public string SiteFixedcharge { get; set; }
        public decimal? SiteLeavefactor { get; set; }
        public int? SiteNstarttime { get; set; }
        public int? SiteNendtime { get; set; }
        public decimal? SiteShifthours { get; set; }
        public decimal? SiteFixedleavecycle { get; set; }
        public string SiteNsfs { get; set; }
        public decimal? SitePayrolnsallowance { get; set; }
        public string SitePhpay { get; set; }
        public int? SiteInvoicegroupingrunid { get; set; }
        public string SiteInvoicensfs { get; set; }
        public string SitePaynsfs { get; set; }
        public string SiteRoundnightshiftallow { get; set; }
        public string SiteSmsautomation { get; set; }
        public int? SitePhset { get; set; }
        public string SiteRegion { get; set; }
        public int? SiteNsbceashiftstart { get; set; }
        public int? SiteNsbceashiftend { get; set; }
        public string SiteShiftcalculation { get; set; }
        public string SiteNsbceatype { get; set; }
    }
}
