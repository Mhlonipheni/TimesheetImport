using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TimesheetImport.Infrastructure.Repository.Models;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public partial class RMSContext : DbContext
    {
        public RMSContext()
        {
        }

        public RMSContext(DbContextOptions<RMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=197.189.212.178,56431;Database=RMS; user id=karisani; password=CvRmFHIuH74Duxu;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.HasKey(e => e.TimeTimesheetId);

                entity.ToTable("Timesheet");

                entity.HasIndex(e => new { e.TimeDeleted, e.TimeEmployeeid, e.TimeShift, e.TimeTimesheetId, e.TimeStartdate, e.TimeEnddate }, "IDX_Timesheet_time_Deleted_time_employeeid_time_shift_time_TimesheetID_time_startdate_time_enddate");

                entity.HasIndex(e => new { e.TimeDeleted, e.TimePosition, e.TimeShift, e.TimeApproved, e.TimeInvoicerunid, e.TimeStartdate }, "IDX_Timesheet_time_Deleted_time_position_time_shift_time_approved_time_invoicerunid_time_startdate");

                entity.HasIndex(e => new { e.TimeUpdatedDate, e.TimeDeleted }, "IDX_Timesheet_time_UpdatedDate_time_Deleted");

                entity.HasIndex(e => new { e.TimeSiteid, e.TimeInvoicerunid, e.TimeApproved, e.TimeNormalhrs, e.TimeNightshifthrs, e.TimeTimesheetId, e.TimePosition, e.TimeDeleted, e.TimeShift, e.TimeStartdate, e.TimeSundayhrs, e.TimePhhrs }, "_dta_index_Timesheet_7_1377191381__K28_K58_K39_K22_K25_K1_K35_K7_K36_K20_K26_K24");

                entity.HasIndex(e => new { e.TimeSiteid, e.TimeInvoicerunid, e.TimeApproved, e.TimePhhrs, e.TimeTimesheetId, e.TimePosition, e.TimeDeleted, e.TimeShift, e.TimeStartdate }, "_dta_index_Timesheet_7_1377191381__K28_K58_K39_K24_K1_K35_K7_K36_K20");

                entity.HasIndex(e => new { e.TimeSiteid, e.TimeInvoicerunid, e.TimeApproved, e.TimeNightshifthrs, e.TimeTimesheetId, e.TimePosition, e.TimeDeleted, e.TimeStartdate, e.TimeSundayhrs, e.TimePhhrs, e.TimeShift }, "_dta_index_Timesheet_7_1377191381__K28_K58_K39_K25_K1_K35_K7_K20_K26_K24_K36");

                entity.HasIndex(e => new { e.TimeSiteid, e.TimeInvoicerunid, e.TimeApproved, e.TimeSundayhrs, e.TimeTimesheetId, e.TimePosition, e.TimeDeleted, e.TimeStartdate, e.TimePhhrs, e.TimeShift, e.TimeNightshifthrs, e.TimeCalculatedhrs, e.TimeOvertimehrs }, "_dta_index_Timesheet_7_1377191381__K28_K58_K39_K26_K1_K35_K7_K20_K24_K36_K25_K52_K23");

                entity.HasIndex(e => new { e.TimeSiteid, e.TimeInvoicerunid, e.TimeApproved, e.TimeCalculatedhrs, e.TimeTimesheetId, e.TimePosition, e.TimeDeleted, e.TimeStartdate }, "_dta_index_Timesheet_7_1377191381__K28_K58_K39_K52_K1_K35_K7_K20");

                entity.HasIndex(e => new { e.TimeInvoicerunid, e.TimeApproved, e.TimeSiteid, e.TimePosition, e.TimeDeleted, e.TimeStartdate, e.TimeCalculatedhrs, e.TimeOvertimehrs }, "_dta_index_Timesheet_7_1377191381__K58_K39_K28_K35_K7_K20_K52_K23_1");

                entity.Property(e => e.TimeTimesheetId).HasColumnName("time_TimesheetID");

                entity.Property(e => e.TimeApproved)
                    .HasMaxLength(1)
                    .HasColumnName("time_approved")
                    .IsFixedLength();

                entity.Property(e => e.TimeBatchNo).HasColumnName("time_BatchNo");

                entity.Property(e => e.TimeBreaktimehrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_breaktimehrs");

                entity.Property(e => e.TimeCalcnewtrainhrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_calcnewtrainhrs");

                entity.Property(e => e.TimeCalculatedhrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_calculatedhrs");

                entity.Property(e => e.TimeCaseId).HasColumnName("time_CaseId");

                entity.Property(e => e.TimeCompanyId).HasColumnName("time_CompanyId");

                entity.Property(e => e.TimeCreatedBy).HasColumnName("time_CreatedBy");

                entity.Property(e => e.TimeCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("time_CreatedDate");

                entity.Property(e => e.TimeDeleted).HasColumnName("time_Deleted");

                entity.Property(e => e.TimeEmployeeid).HasColumnName("time_employeeid");

                entity.Property(e => e.TimeEmployeeidsearch).HasColumnName("time_employeeidsearch");

                entity.Property(e => e.TimeEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("time_enddate");

                entity.Property(e => e.TimeEnddatesearch)
                    .HasColumnType("datetime")
                    .HasColumnName("time_enddatesearch");

                entity.Property(e => e.TimeEndtime)
                    .HasMaxLength(4)
                    .HasColumnName("time_endtime")
                    .IsFixedLength();

                entity.Property(e => e.TimeIncludedweekrun)
                    .HasMaxLength(1)
                    .HasColumnName("time_includedweekrun")
                    .IsFixedLength();

                entity.Property(e => e.TimeInvoiced)
                    .HasMaxLength(1)
                    .HasColumnName("time_invoiced")
                    .IsFixedLength();

                entity.Property(e => e.TimeInvoiceid).HasColumnName("time_invoiceid");

                entity.Property(e => e.TimeInvoicerunid).HasColumnName("time_invoicerunid");

                entity.Property(e => e.TimeLeadId).HasColumnName("time_LeadId");

                entity.Property(e => e.TimeName)
                    .HasMaxLength(30)
                    .HasColumnName("time_Name");

                entity.Property(e => e.TimeNewweek).HasColumnName("time_newweek");

                entity.Property(e => e.TimeNightshifthrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_nightshifthrs");

                entity.Property(e => e.TimeNightshifthrstotal)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_nightshifthrstotal");

                entity.Property(e => e.TimeNightshifthrstotalCid).HasColumnName("time_nightshifthrstotal_CID");

                entity.Property(e => e.TimeNormalhrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_normalhrs");

                entity.Property(e => e.TimeNormalhrstotal)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_normalhrstotal");

                entity.Property(e => e.TimeNormalhrstotalCid).HasColumnName("time_normalhrstotal_CID");

                entity.Property(e => e.TimeOpportunityId).HasColumnName("time_OpportunityId");

                entity.Property(e => e.TimeOrderId).HasColumnName("time_OrderId");

                entity.Property(e => e.TimeOverride)
                    .HasMaxLength(1)
                    .HasColumnName("time_Override")
                    .IsFixedLength();

                entity.Property(e => e.TimeOvertimehrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_overtimehrs");

                entity.Property(e => e.TimeOvertimehrstotal)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_overtimehrstotal");

                entity.Property(e => e.TimeOvertimehrstotalCid).HasColumnName("time_overtimehrstotal_CID");

                entity.Property(e => e.TimePayrunid).HasColumnName("time_payrunid");

                entity.Property(e => e.TimePersonId).HasColumnName("time_PersonId");

                entity.Property(e => e.TimePhhrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_phhrs");

                entity.Property(e => e.TimePlaceholder1)
                    .HasMaxLength(1)
                    .HasColumnName("time_placeholder1")
                    .IsFixedLength();

                entity.Property(e => e.TimePosition).HasColumnName("time_position");

                entity.Property(e => e.TimePositionsearch).HasColumnName("time_positionsearch");

                entity.Property(e => e.TimePrechargesheetid).HasColumnName("time_prechargesheetid");

                entity.Property(e => e.TimeQuoteId).HasColumnName("time_QuoteId");

                entity.Property(e => e.TimeSecterr).HasColumnName("time_Secterr");

                entity.Property(e => e.TimeShift)
                    .HasMaxLength(40)
                    .HasColumnName("time_shift");

                entity.Property(e => e.TimeSiteid).HasColumnName("time_siteid");

                entity.Property(e => e.TimeSource)
                    .HasMaxLength(20)
                    .HasColumnName("time_Source");

                entity.Property(e => e.TimeStage)
                    .HasMaxLength(40)
                    .HasColumnName("time_stage");

                entity.Property(e => e.TimeStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("time_startdate");

                entity.Property(e => e.TimeStartdatesearch)
                    .HasColumnType("datetime")
                    .HasColumnName("time_startdatesearch");

                entity.Property(e => e.TimeStarttime)
                    .HasMaxLength(4)
                    .HasColumnName("time_starttime")
                    .IsFixedLength();

                entity.Property(e => e.TimeStatus)
                    .HasMaxLength(40)
                    .HasColumnName("time_Status");

                entity.Property(e => e.TimeSundayhrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_sundayhrs");

                entity.Property(e => e.TimeTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("time_TimeStamp");

                entity.Property(e => e.TimeTimesheetrunid).HasColumnName("time_timesheetrunid");

                entity.Property(e => e.TimeUpdatedBy).HasColumnName("time_UpdatedBy");

                entity.Property(e => e.TimeUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("time_UpdatedDate");

                entity.Property(e => e.TimeWeek).HasColumnName("time_week");

                entity.Property(e => e.TimeWorkedhrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("time_workedhrs");

                entity.Property(e => e.TimeWorkflowId).HasColumnName("time_WorkflowId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
