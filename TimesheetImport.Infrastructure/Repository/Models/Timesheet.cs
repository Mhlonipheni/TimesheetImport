using System;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public class Timesheet
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime TimeStamp { get; set; }
        public int? Deleted { get; set; }
        public int? Secterr { get; set; }
        public int? WorkflowId { get; set; }
        public string? Status { get; set; }
        public int? CompanyId { get; set; }
        public int? PersonId { get; set; }
        public int? OpportunityId { get; set; }
        public int? OrderId { get; set; }
        public int? QuoteId { get; set; }
        public int? LeadId { get; set; }
        public int? CaseId { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public Double? normalhrs { get; set; }
        public Double? overtimehrs { get; set; }
        public Double? phhrs { get; set; }
        public Double? nightshifthrs { get; set; }
        public Double? sundayhrs { get; set; }
        public string? stage { get; set; }
        public int? siteid { get; set; }
        public int? prechargesheetid { get; set; }
        public Double? breaktimehrs { get; set; }
        public Double? normalhrstotal { get; set; }
        public int? normalhrstotal_CID { get; set; }
        public int? overtimehrstotal { get; set; }
        public int? overtimehrstotal_CID { get; set; }
        public int? position { get; set; }
        public string shift { get; set; }
        public string? starttime { get; set; }
        public string? endtime { get; set; }
        public string? approved { get; set; }
        public string? placeholder1 { get; set; }
        public Double? nightshifthrstotal { get; set; }
        public int? nightshifthrstotal_CID { get; set; }
        public int employeeidsearch { get; set; }
        public int positionsearch { get; set; }
        public string? includedweekrun { get; set; }
        public int? invoiced { get; set; }
        public Double workedhrs { get; set; }
        public DateTime? startdatesearch { get; set; }
        public DateTime? enddatesearch { get; set; }
        public string Source { get; set; }
        public int BatchNo { get; set; }
        public string calculatedhrs { get; set; }
        public int payrunid { get; set; }
        public int week { get; set; }
        public int timesheetrunid { get; set; }
        public int? invoiceid { get; set; }
        public string? calcnewtrainhrs { get; set; }
        public int? invoicerunid { get; set; }
        public string Override { get; set; }
        public int newweek { get; set; }

    }
}
