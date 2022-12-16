using ConsoleApp5.Models;
using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HolidaySetItem> HolidaySetItems { get; set; }
        public virtual DbSet<NewProduct> NewProducts { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<Timesheet> Timesheets { get; set; }
        public virtual DbSet<TimesheetRun> TimesheetRuns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompCompanyId)
                    .HasName("PK__Company__76CBEED90D30ECFA");

                entity.ToTable("Company");

                entity.HasIndex(e => e.CompDeleted, "IDX_Comp_Deleted")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.CompName, "IDX_Comp_Name")
                    .HasFillFactor(80);

                entity.HasIndex(e => new { e.CompCompanyId, e.CompDeleted, e.CompName }, "IDX_Comp_NameEx")
                    .HasFillFactor(80);

                entity.HasIndex(e => new { e.CompDeleted, e.CompUpdatedDate }, "IDX_Comp_QUICKFIND_Deleted_UpdatedDate");

                entity.HasIndex(e => e.CompSecTerr, "IDX_Comp_Secterr")
                    .HasFillFactor(80);

                entity.Property(e => e.CompCompanyId).HasColumnName("Comp_CompanyId");

                entity.Property(e => e.CompAccountingnumber)
                    .HasMaxLength(20)
                    .HasColumnName("comp_accountingnumber");

                entity.Property(e => e.CompChannelId).HasColumnName("Comp_ChannelID");

                entity.Property(e => e.CompCreatedBy).HasColumnName("Comp_CreatedBy");

                entity.Property(e => e.CompCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Comp_CreatedDate");

                entity.Property(e => e.CompDeleted).HasColumnName("Comp_Deleted");

                entity.Property(e => e.CompEmployees)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_Employees");

                entity.Property(e => e.CompIndCode)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_IndCode");

                entity.Property(e => e.CompIntegratedSystems)
                    .HasMaxLength(255)
                    .HasColumnName("Comp_IntegratedSystems");

                entity.Property(e => e.CompIntforeignid)
                    .HasMaxLength(255)
                    .HasColumnName("comp_intforeignid");

                entity.Property(e => e.CompIntid).HasColumnName("comp_intid");

                entity.Property(e => e.CompIntlastsyncdate)
                    .HasColumnType("datetime")
                    .HasColumnName("comp_intlastsyncdate");

                entity.Property(e => e.CompInvoicegroupingrunid).HasColumnName("comp_invoicegroupingrunid");

                entity.Property(e => e.CompLibraryDir)
                    .HasMaxLength(255)
                    .HasColumnName("Comp_LibraryDir");

                entity.Property(e => e.CompMailRestriction)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_MailRestriction");

                entity.Property(e => e.CompName)
                    .HasMaxLength(60)
                    .HasColumnName("Comp_Name");

                entity.Property(e => e.CompOptOut)
                    .HasMaxLength(1)
                    .HasColumnName("Comp_OptOut")
                    .IsFixedLength();

                entity.Property(e => e.CompPrimaryAccountId).HasColumnName("Comp_PrimaryAccountId");

                entity.Property(e => e.CompPrimaryAddressId).HasColumnName("Comp_PrimaryAddressId");

                entity.Property(e => e.CompPrimaryPersonId).HasColumnName("Comp_PrimaryPersonId");

                entity.Property(e => e.CompPrimaryUserId).HasColumnName("Comp_PrimaryUserId");

                entity.Property(e => e.CompPromote)
                    .HasMaxLength(1)
                    .HasColumnName("comp_promote")
                    .IsFixedLength();

                entity.Property(e => e.CompRevenue)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_Revenue");

                entity.Property(e => e.CompSecTerr).HasColumnName("Comp_SecTerr");

                entity.Property(e => e.CompSector)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_Sector");

                entity.Property(e => e.CompSlaid).HasColumnName("comp_SLAId");

                entity.Property(e => e.CompSource)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_Source");

                entity.Property(e => e.CompStatus)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_Status");

                entity.Property(e => e.CompTerritory)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_Territory");

                entity.Property(e => e.CompTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Comp_TimeStamp");

                entity.Property(e => e.CompType)
                    .HasMaxLength(40)
                    .HasColumnName("Comp_Type");

                entity.Property(e => e.CompUpdatedBy).HasColumnName("Comp_UpdatedBy");

                entity.Property(e => e.CompUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Comp_UpdatedDate");

                entity.Property(e => e.CompUploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Comp_UploadDate");

                entity.Property(e => e.CompVatnumber)
                    .HasMaxLength(20)
                    .HasColumnName("comp_vatnumber");

                entity.Property(e => e.CompWebSite)
                    .HasMaxLength(100)
                    .HasColumnName("Comp_WebSite");

                entity.Property(e => e.CompWorkflowId).HasColumnName("Comp_WorkflowId");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmplEmployeeId);

                entity.ToTable("Employee");

                entity.HasIndex(e => e.EmplName, "IDX_Employee_Name");

                entity.HasIndex(e => e.EmplClockcode, "IDX_Employee_empl_clockcode");

                entity.Property(e => e.EmplEmployeeId).HasColumnName("Empl_EmployeeID");

                entity.Property(e => e.EmplAccrualtype)
                    .HasMaxLength(40)
                    .HasColumnName("empl_accrualtype");

                entity.Property(e => e.EmplAddtoroster)
                    .HasMaxLength(1)
                    .HasColumnName("empl_addtoroster")
                    .IsFixedLength();

                entity.Property(e => e.EmplAddtorosteruiserid).HasColumnName("empl_addtorosteruiserid");

                entity.Property(e => e.EmplApprovedleavedays).HasColumnName("empl_approvedleavedays");

                entity.Property(e => e.EmplChannelId).HasColumnName("Empl_ChannelId");

                entity.Property(e => e.EmplClockcode)
                    .HasMaxLength(20)
                    .HasColumnName("empl_clockcode");

                entity.Property(e => e.EmplCompanyid).HasColumnName("empl_companyid");

                entity.Property(e => e.EmplCopyaddress)
                    .HasMaxLength(1)
                    .HasColumnName("empl_copyaddress")
                    .IsFixedLength();

                entity.Property(e => e.EmplCreatedBy).HasColumnName("Empl_CreatedBy");

                entity.Property(e => e.EmplCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Empl_CreatedDate");

                entity.Property(e => e.EmplCriminaltestdate)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_criminaltestdate");

                entity.Property(e => e.EmplCriminaltestresult)
                    .HasMaxLength(40)
                    .HasColumnName("empl_criminaltestresult");

                entity.Property(e => e.EmplDateengaged)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_dateengaged");

                entity.Property(e => e.EmplDateofbirth)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_dateofbirth");

                entity.Property(e => e.EmplDeleted).HasColumnName("Empl_Deleted");

                entity.Property(e => e.EmplDepartment)
                    .HasMaxLength(20)
                    .HasColumnName("empl_department");

                entity.Property(e => e.EmplEea1declaration)
                    .HasMaxLength(40)
                    .HasColumnName("empl_eea1declaration");

                entity.Property(e => e.EmplEmailaddress)
                    .HasMaxLength(255)
                    .HasColumnName("empl_emailaddress");

                entity.Property(e => e.EmplEmergencycellphone)
                    .HasMaxLength(20)
                    .HasColumnName("empl_emergencycellphone");

                entity.Property(e => e.EmplEmergencycontact)
                    .HasMaxLength(60)
                    .HasColumnName("empl_emergencycontact");

                entity.Property(e => e.EmplEmergencycontrel)
                    .HasMaxLength(40)
                    .HasColumnName("empl_emergencycontrel");

                entity.Property(e => e.EmplEmergencyworknumber)
                    .HasMaxLength(20)
                    .HasColumnName("empl_emergencyworknumber");

                entity.Property(e => e.EmplEmploymentcategory)
                    .HasMaxLength(20)
                    .HasColumnName("empl_employmentcategory");

                entity.Property(e => e.EmplEvalsick)
                    .HasMaxLength(40)
                    .HasColumnName("empl_evalsick");

                entity.Property(e => e.EmplFirstname)
                    .HasMaxLength(60)
                    .HasColumnName("empl_firstname");

                entity.Property(e => e.EmplFixedrovertime)
                    .HasMaxLength(1)
                    .HasColumnName("empl_fixedrovertime")
                    .IsFixedLength();

                entity.Property(e => e.EmplFrdaysdue).HasColumnName("empl_frdaysdue");

                entity.Property(e => e.EmplGender)
                    .HasMaxLength(40)
                    .HasColumnName("empl_gender");

                entity.Property(e => e.EmplGroup)
                    .HasMaxLength(40)
                    .HasColumnName("empl_group");

                entity.Property(e => e.EmplHrsperweek)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("empl_hrsperweek");

                entity.Property(e => e.EmplIdnumber)
                    .HasMaxLength(13)
                    .HasColumnName("empl_idnumber");

                entity.Property(e => e.EmplInitials)
                    .HasMaxLength(20)
                    .HasColumnName("empl_initials");

                entity.Property(e => e.EmplIoddaysdue).HasColumnName("empl_ioddaysdue");

                entity.Property(e => e.EmplIrp5startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_irp5startdate");

                entity.Property(e => e.EmplJobgrade)
                    .HasMaxLength(20)
                    .HasColumnName("empl_jobgrade");

                entity.Property(e => e.EmplKnownas)
                    .HasMaxLength(30)
                    .HasColumnName("empl_knownas");

                entity.Property(e => e.EmplLanguage)
                    .HasMaxLength(40)
                    .HasColumnName("empl_language");

                entity.Property(e => e.EmplLastname)
                    .HasMaxLength(60)
                    .HasColumnName("empl_lastname");

                entity.Property(e => e.EmplLeavedaysdue).HasColumnName("empl_leavedaysdue");

                entity.Property(e => e.EmplLeaveratio)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("empl_leaveratio");

                entity.Property(e => e.EmplLiteracytestdate)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_literacytestdate");

                entity.Property(e => e.EmplLiteracytestresults)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("empl_literacytestresults");

                entity.Property(e => e.EmplMaidenname)
                    .HasMaxLength(30)
                    .HasColumnName("empl_maidenname");

                entity.Property(e => e.EmplManager)
                    .HasMaxLength(60)
                    .HasColumnName("empl_manager");

                entity.Property(e => e.EmplMaritalstatus)
                    .HasMaxLength(40)
                    .HasColumnName("empl_maritalstatus");

                entity.Property(e => e.EmplMedicalaidname)
                    .HasMaxLength(20)
                    .HasColumnName("empl_medicalaidname");

                entity.Property(e => e.EmplMedicalaidnumber)
                    .HasMaxLength(20)
                    .HasColumnName("empl_medicalaidnumber");

                entity.Property(e => e.EmplMiddlename)
                    .HasMaxLength(30)
                    .HasColumnName("empl_middlename");

                entity.Property(e => e.EmplMobilenumber)
                    .HasMaxLength(30)
                    .HasColumnName("empl_mobilenumber");

                entity.Property(e => e.EmplName)
                    .HasMaxLength(30)
                    .HasColumnName("Empl_Name");

                entity.Property(e => e.EmplNohrsleave)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("empl_nohrsleave");

                entity.Property(e => e.EmplPaAddress1)
                    .HasMaxLength(20)
                    .HasColumnName("empl_pa_address1");

                entity.Property(e => e.EmplPaAddress2)
                    .HasMaxLength(40)
                    .HasColumnName("empl_pa_address2");

                entity.Property(e => e.EmplPaAddress3)
                    .HasMaxLength(40)
                    .HasColumnName("empl_pa_address3");

                entity.Property(e => e.EmplPaAddress4)
                    .HasMaxLength(255)
                    .HasColumnName("empl_pa_address4");

                entity.Property(e => e.EmplPaCity)
                    .HasMaxLength(30)
                    .HasColumnName("empl_pa_city");

                entity.Property(e => e.EmplPaCountry)
                    .HasMaxLength(40)
                    .HasColumnName("empl_pa_country");

                entity.Property(e => e.EmplPaPostcode)
                    .HasMaxLength(4)
                    .HasColumnName("empl_pa_postcode");

                entity.Property(e => e.EmplPaState)
                    .HasMaxLength(30)
                    .HasColumnName("empl_pa_state");

                entity.Property(e => e.EmplPassportcountry)
                    .HasMaxLength(40)
                    .HasColumnName("empl_passportcountry");

                entity.Property(e => e.EmplPassportexpirydate)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_passportexpirydate");

                entity.Property(e => e.EmplPassportnumber)
                    .HasMaxLength(20)
                    .HasColumnName("empl_passportnumber");

                entity.Property(e => e.EmplPayforph)
                    .HasMaxLength(1)
                    .HasColumnName("empl_payforph")
                    .IsFixedLength();

                entity.Property(e => e.EmplPayfrequency)
                    .HasMaxLength(40)
                    .HasColumnName("empl_payfrequency");

                entity.Property(e => e.EmplPaymentmethod)
                    .HasMaxLength(40)
                    .HasColumnName("empl_paymentmethod");

                entity.Property(e => e.EmplPaypoint)
                    .HasMaxLength(20)
                    .HasColumnName("empl_paypoint");

                entity.Property(e => e.EmplPayrolstatus)
                    .HasMaxLength(40)
                    .HasColumnName("empl_payrolstatus");

                entity.Property(e => e.EmplPayrun)
                    .HasMaxLength(3)
                    .HasColumnName("empl_payrun");

                entity.Property(e => e.EmplPayruncategory)
                    .HasMaxLength(40)
                    .HasColumnName("empl_payruncategory");

                entity.Property(e => e.EmplPayruncategorydate)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_payruncategorydate");

                entity.Property(e => e.EmplPhonenumber)
                    .HasMaxLength(20)
                    .HasColumnName("empl_phonenumber");

                entity.Property(e => e.EmplPool)
                    .HasMaxLength(40)
                    .HasColumnName("empl_pool");

                entity.Property(e => e.EmplPosition).HasColumnName("empl_position");

                entity.Property(e => e.EmplPositionsearch).HasColumnName("empl_positionsearch");

                entity.Property(e => e.EmplPpebootsize)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("empl_ppebootsize");

                entity.Property(e => e.EmplPpesuitsize)
                    .HasMaxLength(40)
                    .HasColumnName("empl_ppesuitsize");

                entity.Property(e => e.EmplPpewaistsize)
                    .HasMaxLength(40)
                    .HasColumnName("empl_ppewaistsize");

                entity.Property(e => e.EmplRaAddress1)
                    .HasMaxLength(20)
                    .HasColumnName("empl_ra_address1");

                entity.Property(e => e.EmplRaAddress2)
                    .HasMaxLength(40)
                    .HasColumnName("empl_ra_address2");

                entity.Property(e => e.EmplRaAddress3)
                    .HasMaxLength(40)
                    .HasColumnName("empl_ra_address3");

                entity.Property(e => e.EmplRaAddress4)
                    .HasMaxLength(255)
                    .HasColumnName("empl_ra_address4");

                entity.Property(e => e.EmplRaCity)
                    .HasMaxLength(30)
                    .HasColumnName("empl_ra_city");

                entity.Property(e => e.EmplRaCountry)
                    .HasMaxLength(40)
                    .HasColumnName("empl_ra_country");

                entity.Property(e => e.EmplRaPostcode)
                    .HasMaxLength(4)
                    .HasColumnName("empl_ra_postcode");

                entity.Property(e => e.EmplRaState)
                    .HasMaxLength(30)
                    .HasColumnName("empl_ra_state");

                entity.Property(e => e.EmplReasonstatuschange).HasColumnName("empl_reasonstatuschange");

                entity.Property(e => e.EmplRegioncode)
                    .HasMaxLength(40)
                    .HasColumnName("empl_regioncode");

                entity.Property(e => e.EmplRosterid).HasColumnName("empl_rosterid");

                entity.Property(e => e.EmplRsccode)
                    .HasMaxLength(20)
                    .HasColumnName("empl_rsccode");

                entity.Property(e => e.EmplSacitizen)
                    .HasMaxLength(40)
                    .HasColumnName("empl_sacitizen");

                entity.Property(e => e.EmplSalutation)
                    .HasMaxLength(40)
                    .HasColumnName("empl_salutation");

                entity.Property(e => e.EmplSdaysdue).HasColumnName("empl_sdaysdue");

                entity.Property(e => e.EmplSecterr).HasColumnName("Empl_Secterr");

                entity.Property(e => e.EmplSiteeffectivedate)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_siteeffectivedate");

                entity.Property(e => e.EmplSiteid).HasColumnName("empl_siteid");

                entity.Property(e => e.EmplSmsaddress)
                    .HasMaxLength(255)
                    .HasColumnName("empl_smsaddress");

                entity.Property(e => e.EmplSmsmessage).HasColumnName("empl_smsmessage");

                entity.Property(e => e.EmplStage)
                    .HasMaxLength(40)
                    .HasColumnName("empl_stage");

                entity.Property(e => e.EmplStatus)
                    .HasMaxLength(40)
                    .HasColumnName("Empl_Status");

                entity.Property(e => e.EmplStep)
                    .HasMaxLength(40)
                    .HasColumnName("empl_step");

                entity.Property(e => e.EmplTaxage).HasColumnName("empl_taxage");

                entity.Property(e => e.EmplTaxnumber)
                    .HasMaxLength(20)
                    .HasColumnName("empl_taxnumber");

                entity.Property(e => e.EmplTaxstatus)
                    .HasMaxLength(40)
                    .HasColumnName("empl_taxstatus");

                entity.Property(e => e.EmplTerminatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_terminatedon");

                entity.Property(e => e.EmplTerminationreason)
                    .HasMaxLength(40)
                    .HasColumnName("empl_terminationreason");

                entity.Property(e => e.EmplTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Empl_TimeStamp");

                entity.Property(e => e.EmplTotalhrs)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("empl_totalhrs");

                entity.Property(e => e.EmplUifcontreason)
                    .HasMaxLength(40)
                    .HasColumnName("empl_uifcontreason");

                entity.Property(e => e.EmplUifemploymentstatus)
                    .HasMaxLength(40)
                    .HasColumnName("empl_uifemploymentstatus");

                entity.Property(e => e.EmplUpdatedBy).HasColumnName("Empl_UpdatedBy");

                entity.Property(e => e.EmplUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Empl_UpdatedDate");

                entity.Property(e => e.EmplUserId).HasColumnName("Empl_UserId");

                entity.Property(e => e.EmplWorkflowId).HasColumnName("Empl_WorkflowId");

                entity.Property(e => e.EmplWorkpermitnumber)
                    .HasMaxLength(20)
                    .HasColumnName("empl_workpermitnumber");

                entity.Property(e => e.EmplWpexpirednotify)
                    .HasMaxLength(40)
                    .HasColumnName("empl_wpexpirednotify");

                entity.Property(e => e.EmplWpexpiry1mnth)
                    .HasMaxLength(40)
                    .HasColumnName("empl_wpexpiry1mnth");

                entity.Property(e => e.EmplWpexpiry2mnth)
                    .HasMaxLength(40)
                    .HasColumnName("empl_wpexpiry2mnth");

                entity.Property(e => e.EmplWpexpirydate)
                    .HasColumnType("datetime")
                    .HasColumnName("empl_wpexpirydate");
            });

            modelBuilder.Entity<HolidaySetItem>(entity =>
            {
                entity.HasKey(e => e.HsitCalendarId);

                entity.Property(e => e.HsitCalendarId).HasColumnName("HSIt_CalendarID");

                entity.Property(e => e.HsitCreatedBy).HasColumnName("HSIt_CreatedBy");

                entity.Property(e => e.HsitCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("HSIt_CreatedDate");

                entity.Property(e => e.HsitDeleted).HasColumnName("HSIt_Deleted");

                entity.Property(e => e.HsitHolidayDate)
                    .HasColumnType("datetime")
                    .HasColumnName("HSIt_HolidayDate");

                entity.Property(e => e.HsitHolidayName)
                    .HasMaxLength(40)
                    .HasColumnName("HSIt_HolidayName");

                entity.Property(e => e.HsitHsetHolidaySetId).HasColumnName("HSIt_HSet_HolidaySetId");

                entity.Property(e => e.HsitTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("HSIt_TimeStamp");

                entity.Property(e => e.HsitUpdatedBy).HasColumnName("HSIt_UpdatedBy");

                entity.Property(e => e.HsitUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("HSIt_UpdatedDate");
            });

            modelBuilder.Entity<NewProduct>(entity =>
            {
                entity.HasKey(e => e.ProdProductId);

                entity.ToTable("NewProduct");

                entity.Property(e => e.ProdProductId).HasColumnName("Prod_ProductID");

                entity.Property(e => e.ProdActive)
                    .HasMaxLength(40)
                    .HasColumnName("prod_Active");

                entity.Property(e => e.ProdCode)
                    .HasMaxLength(20)
                    .HasColumnName("prod_code");

                entity.Property(e => e.ProdCreatedBy).HasColumnName("Prod_CreatedBy");

                entity.Property(e => e.ProdCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Prod_CreatedDate");

                entity.Property(e => e.ProdCs)
                    .HasMaxLength(1)
                    .HasColumnName("prod_cs")
                    .IsFixedLength();

                entity.Property(e => e.ProdDeleted).HasColumnName("Prod_Deleted");

                entity.Property(e => e.ProdIntegrationId).HasColumnName("prod_IntegrationId");

                entity.Property(e => e.ProdIntforeignid)
                    .HasMaxLength(255)
                    .HasColumnName("prod_intforeignid");

                entity.Property(e => e.ProdIntid).HasColumnName("prod_intid");

                entity.Property(e => e.ProdIntlastsyncdate)
                    .HasColumnType("datetime")
                    .HasColumnName("prod_intlastsyncdate");

                entity.Property(e => e.ProdName)
                    .HasMaxLength(200)
                    .HasColumnName("prod_name");

                entity.Property(e => e.ProdProductfamilyid).HasColumnName("prod_productfamilyid");

                entity.Property(e => e.ProdPromote)
                    .HasMaxLength(1)
                    .HasColumnName("prod_promote")
                    .IsFixedLength();

                entity.Property(e => e.ProdTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Prod_TimeStamp");

                entity.Property(e => e.ProdTraining)
                    .HasMaxLength(1)
                    .HasColumnName("prod_training")
                    .IsFixedLength();

                entity.Property(e => e.ProdUomcategory).HasColumnName("prod_UOMCategory");

                entity.Property(e => e.ProdUpdatedBy).HasColumnName("Prod_UpdatedBy");

                entity.Property(e => e.ProdUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Prod_UpdatedDate");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.SiteSiteId);

                entity.ToTable("Site");

                entity.Property(e => e.SiteSiteId).HasColumnName("site_SiteID");

                entity.Property(e => e.SiteAddress1)
                    .HasMaxLength(40)
                    .HasColumnName("site_address1");

                entity.Property(e => e.SiteAddress2)
                    .HasMaxLength(40)
                    .HasColumnName("site_address2");

                entity.Property(e => e.SiteCity)
                    .HasMaxLength(30)
                    .HasColumnName("site_city");

                entity.Property(e => e.SiteCompanyId).HasColumnName("site_CompanyId");

                entity.Property(e => e.SiteContactname)
                    .HasMaxLength(40)
                    .HasColumnName("site_contactname");

                entity.Property(e => e.SiteCountry)
                    .HasMaxLength(40)
                    .HasColumnName("site_country");

                entity.Property(e => e.SiteCreatedBy).HasColumnName("site_CreatedBy");

                entity.Property(e => e.SiteCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("site_CreatedDate");

                entity.Property(e => e.SiteDeleted).HasColumnName("site_Deleted");

                entity.Property(e => e.SiteEmailaddress)
                    .HasMaxLength(255)
                    .HasColumnName("site_emailaddress");

                entity.Property(e => e.SiteEndtime).HasColumnName("site_endtime");

                entity.Property(e => e.SiteFixedcharge)
                    .HasMaxLength(40)
                    .HasColumnName("site_fixedcharge");

                entity.Property(e => e.SiteFixedleavecycle)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("site_fixedleavecycle");

                entity.Property(e => e.SiteInvoicegroupingrunid).HasColumnName("site_invoicegroupingrunid");

                entity.Property(e => e.SiteInvoicensfs)
                    .HasMaxLength(40)
                    .HasColumnName("site_invoicensfs");

                entity.Property(e => e.SiteLeavefactor)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("site_leavefactor");

                entity.Property(e => e.SiteName)
                    .HasMaxLength(30)
                    .HasColumnName("site_Name");

                entity.Property(e => e.SiteNendtime).HasColumnName("site_nendtime");

                entity.Property(e => e.SiteNsfs)
                    .HasMaxLength(40)
                    .HasColumnName("site_nsfs");

                entity.Property(e => e.SiteNstarttime).HasColumnName("site_nstarttime");

                entity.Property(e => e.SitePaynsfs)
                    .HasMaxLength(40)
                    .HasColumnName("site_paynsfs");

                entity.Property(e => e.SitePayrolnsallowance)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("site_payrolnsallowance");

                entity.Property(e => e.SitePhonenumber)
                    .HasMaxLength(20)
                    .HasColumnName("site_phonenumber");

                entity.Property(e => e.SitePhpay)
                    .HasMaxLength(40)
                    .HasColumnName("site_phpay");

                entity.Property(e => e.SitePhset).HasColumnName("site_phset");

                entity.Property(e => e.SitePostcode)
                    .HasMaxLength(10)
                    .HasColumnName("site_postcode");

                entity.Property(e => e.SiteProjectnumber)
                    .HasMaxLength(20)
                    .HasColumnName("site_projectnumber");

                entity.Property(e => e.SiteRegion)
                    .HasMaxLength(40)
                    .HasColumnName("site_region");

                entity.Property(e => e.SiteRoundnightshiftallow)
                    .HasMaxLength(40)
                    .HasColumnName("site_roundnightshiftallow");

                entity.Property(e => e.SiteSecterr).HasColumnName("site_Secterr");

                entity.Property(e => e.SiteShift)
                    .HasMaxLength(40)
                    .HasColumnName("site_shift");

                entity.Property(e => e.SiteShifthours)
                    .HasColumnType("numeric(24, 6)")
                    .HasColumnName("site_shifthours");

                entity.Property(e => e.SiteSmsautomation)
                    .HasMaxLength(1)
                    .HasColumnName("site_smsautomation")
                    .IsFixedLength();

                entity.Property(e => e.SiteStarttime).HasColumnName("site_starttime");

                entity.Property(e => e.SiteState)
                    .HasMaxLength(30)
                    .HasColumnName("site_state");

                entity.Property(e => e.SiteStatus)
                    .HasMaxLength(40)
                    .HasColumnName("site_Status");

                entity.Property(e => e.SiteTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("site_TimeStamp");

                entity.Property(e => e.SiteUpdatedBy).HasColumnName("site_UpdatedBy");

                entity.Property(e => e.SiteUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("site_UpdatedDate");
            });

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

            modelBuilder.Entity<TimesheetRun>(entity =>
            {
                entity.HasKey(e => e.TimhTimesheetRunId);

                entity.ToTable("TimesheetRun");

                entity.Property(e => e.TimhTimesheetRunId).HasColumnName("timh_TimesheetRunID");

                entity.Property(e => e.TimhChannelId).HasColumnName("timh_ChannelId");

                entity.Property(e => e.TimhCreatedBy).HasColumnName("timh_CreatedBy");

                entity.Property(e => e.TimhCreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("timh_CreatedDate");

                entity.Property(e => e.TimhDate)
                    .HasColumnType("datetime")
                    .HasColumnName("timh_date");

                entity.Property(e => e.TimhDeleted).HasColumnName("timh_Deleted");

                entity.Property(e => e.TimhName)
                    .HasMaxLength(30)
                    .HasColumnName("timh_Name");

                entity.Property(e => e.TimhRosterid).HasColumnName("timh_rosterid");

                entity.Property(e => e.TimhSecterr).HasColumnName("timh_Secterr");

                entity.Property(e => e.TimhShift)
                    .HasMaxLength(40)
                    .HasColumnName("timh_shift");

                entity.Property(e => e.TimhSiteid).HasColumnName("timh_siteid");

                entity.Property(e => e.TimhStage)
                    .HasMaxLength(40)
                    .HasColumnName("timh_stage");

                entity.Property(e => e.TimhStatus)
                    .HasMaxLength(40)
                    .HasColumnName("timh_Status");

                entity.Property(e => e.TimhTimeStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timh_TimeStamp");

                entity.Property(e => e.TimhTimesheetscreated)
                    .HasMaxLength(1)
                    .HasColumnName("timh_timesheetscreated")
                    .IsFixedLength();

                entity.Property(e => e.TimhUpdatedBy).HasColumnName("timh_UpdatedBy");

                entity.Property(e => e.TimhUpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("timh_UpdatedDate");

                entity.Property(e => e.TimhUserId).HasColumnName("timh_UserId");

                entity.Property(e => e.TimhWorkflowId).HasColumnName("timh_WorkflowId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
