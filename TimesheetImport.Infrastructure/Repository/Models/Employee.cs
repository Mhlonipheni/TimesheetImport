﻿using System;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class Employee
    {
        public int EmplEmployeeId { get; set; }

        public int? EmplCreatedBy { get; set; }

        public DateTime? EmplCreatedDate { get; set; }

        public int? EmplUpdatedBy { get; set; }

        public DateTime? EmplUpdatedDate { get; set; }

        public DateTime? EmplTimeStamp { get; set; }

        public int? EmplDeleted { get; set; }

        public int? EmplSecterr { get; set; }

        public string EmplName { get; set; }

        public int? EmplWorkflowId { get; set; }

        public string EmplStatus { get; set; }

        public int? EmplUserId { get; set; }

        public int? EmplChannelId { get; set; }

        public string EmplIdnumber { get; set; }

        public string EmplSalutation { get; set; }

        public string EmplFirstname { get; set; }

        public string EmplLastname { get; set; }

        public string EmplMiddlename { get; set; }

        public string EmplMaidenname { get; set; }

        public DateTime? EmplDateofbirth { get; set; }

        public string EmplPassportnumber { get; set; }

        public string EmplLanguage { get; set; }

        public string EmplGender { get; set; }

        public string EmplMaritalstatus { get; set; }

        public DateTime? EmplDateengaged { get; set; }

        public DateTime? EmplTerminatedon { get; set; }

        public string EmplPassportcountry { get; set; }

        public string EmplInitials { get; set; }

        public string EmplEmergencycontact { get; set; }

        public string EmplEmergencycellphone { get; set; }

        public string EmplEmergencyworknumber { get; set; }

        public string EmplRegioncode { get; set; }

        public string EmplClockcode { get; set; }

        public string EmplKnownas { get; set; }

        public string EmplSacitizen { get; set; }

        public DateTime? EmplPassportexpirydate { get; set; }

        public string EmplWorkpermitnumber { get; set; }

        public DateTime? EmplWpexpirydate { get; set; }

        public string EmplGroup { get; set; }

        public string EmplTaxnumber { get; set; }

        public string EmplTaxstatus { get; set; }

        public DateTime? EmplIrp5startdate { get; set; }

        public int? EmplTaxage { get; set; }

        public string EmplUifcontreason { get; set; }

        public string EmplPaymentmethod { get; set; }

        public string EmplUifemploymentstatus { get; set; }

        public string EmplEmergencycontrel { get; set; }

        public decimal? EmplPpebootsize { get; set; }

        public string EmplPpewaistsize { get; set; }

        public string EmplPpesuitsize { get; set; }

        public DateTime? EmplLiteracytestdate { get; set; }

        public decimal? EmplLiteracytestresults { get; set; }

        public DateTime? EmplCriminaltestdate { get; set; }

        public string EmplCriminaltestresult { get; set; }

        public string EmplEea1declaration { get; set; }

        public string EmplJobgrade { get; set; }

        public string EmplEmploymentcategory { get; set; }

        public string EmplRsccode { get; set; }

        public string EmplDepartment { get; set; }

        public string EmplPaypoint { get; set; }

        public string EmplManager { get; set; }

        public string EmplMedicalaidname { get; set; }

        public string EmplMedicalaidnumber { get; set; }

        public int? EmplCompanyid { get; set; }

        public string EmplStage { get; set; }

        public string EmplRaAddress1 { get; set; }

        public string EmplPaAddress1 { get; set; }

        public string EmplRaAddress2 { get; set; }

        public string EmplRaAddress3 { get; set; }

        public string EmplRaCity { get; set; }

        public string EmplRaState { get; set; }

        public string EmplRaPostcode { get; set; }

        public string EmplPaAddress2 { get; set; }

        public string EmplPaAddress3 { get; set; }

        public string EmplPaCity { get; set; }

        public string EmplPaState { get; set; }

        public string EmplPaPostcode { get; set; }

        public string EmplEmailaddress { get; set; }

        public string EmplMobilenumber { get; set; }

        public string EmplPhonenumber { get; set; }

        public int? EmplPosition { get; set; }

        public string EmplStep { get; set; }

        public string EmplReasonstatuschange { get; set; }

        public decimal? EmplHrsperweek { get; set; }

        public int? EmplSiteid { get; set; }

        public string EmplPayrolstatus { get; set; }

        public string EmplPaAddress4 { get; set; }

        public string EmplPaCountry { get; set; }

        public string EmplRaCountry { get; set; }

        public string EmplRaAddress4 { get; set; }

        public string EmplPayrun { get; set; }

        public string EmplCopyaddress { get; set; }

        public string EmplFixedrovertime { get; set; }

        public DateTime? EmplSiteeffectivedate { get; set; }

        public string EmplPayfrequency { get; set; }

        public string EmplAddtoroster { get; set; }

        public int? EmplAddtorosteruiserid { get; set; }

        public int? EmplRosterid { get; set; }

        public int? EmplPositionsearch { get; set; }

        public string EmplPayforph { get; set; }

        public string EmplAccrualtype { get; set; }

        public decimal? EmplLeaveratio { get; set; }

        public string EmplPayruncategory { get; set; }

        public decimal? EmplTotalhrs { get; set; }

        public int? EmplLeavedaysdue { get; set; }

        public decimal? EmplNohrsleave { get; set; }

        public int? EmplApprovedleavedays { get; set; }

        public int? EmplFrdaysdue { get; set; }

        public int? EmplSdaysdue { get; set; }

        public int? EmplIoddaysdue { get; set; }

        public string EmplTerminationreason { get; set; }

        public DateTime? EmplPayruncategorydate { get; set; }

        public string EmplEvalsick { get; set; }

        public string EmplPool { get; set; }

        public string EmplWpexpirednotify { get; set; }

        public string EmplSmsaddress { get; set; }

        public string EmplWpexpiry1mnth { get; set; }

        public string EmplWpexpiry2mnth { get; set; }

        public string EmplSmsmessage { get; set; }
    }
}