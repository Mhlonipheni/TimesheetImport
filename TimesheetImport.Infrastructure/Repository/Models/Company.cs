using System;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class Company
    {
        public int CompCompanyId { get; set; }
        public int? CompPrimaryPersonId { get; set; }
        public int? CompPrimaryAddressId { get; set; }
        public int? CompPrimaryUserId { get; set; }
        public string CompName { get; set; }
        public string CompType { get; set; }
        public string CompStatus { get; set; }
        public string CompSource { get; set; }
        public string CompTerritory { get; set; }
        public string CompRevenue { get; set; }
        public string CompEmployees { get; set; }
        public string CompSector { get; set; }
        public string CompIndCode { get; set; }
        public string CompWebSite { get; set; }
        public string CompMailRestriction { get; set; }
        public int? CompCreatedBy { get; set; }
        public DateTime? CompCreatedDate { get; set; }
        public int? CompUpdatedBy { get; set; }
        public DateTime? CompUpdatedDate { get; set; }
        public DateTime? CompTimeStamp { get; set; }
        public byte? CompDeleted { get; set; }
        public string CompLibraryDir { get; set; }
        public int? CompChannelId { get; set; }
        public int? CompSecTerr { get; set; }
        public int? CompWorkflowId { get; set; }
        public DateTime? CompUploadDate { get; set; }
        public int? CompSlaid { get; set; }
        public int? CompPrimaryAccountId { get; set; }
        public string CompIntforeignid { get; set; }
        public int? CompIntid { get; set; }
        public DateTime? CompIntlastsyncdate { get; set; }
        public string CompPromote { get; set; }
        public string CompOptOut { get; set; }
        public string CompAccountingnumber { get; set; }
        public string CompVatnumber { get; set; }
        public string CompIntegratedSystems { get; set; }
        public int? CompInvoicegroupingrunid { get; set; }
    }
}
