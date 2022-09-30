using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.TimesheetModels;

namespace TimesheetImport.Infrastructure.Repository.ModelMappings
{
    public static class TimesheetSiteMapper
    {
        public static List<TimesheetSite> MapFromTimesheetSite(List<TimesheetSiteModel> model)
        {
            return model.Select(s => new TimesheetSite()
            {
                SiteId = s.site_SiteID,
                SiteName = s.site_Name
            }).ToList();
        }

        public static List<Timesheet> FromFileToTimesheets(FileUploadRequest fileUploadRequest)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            var timesheets = new List<Timesheet>();

            //using (var stream = File.Open("Timesheet.xlsx", FileMode.Open, FileAccess.Read))
            // {

            //using (var reader = ExcelReaderFactory.CreateReader(stream))
            using (var reader = ExcelReaderFactory.CreateReader(fileUploadRequest.File))
            {
                var result = reader.AsDataSet();
                bool IsNextLineTimesheet = false;
                while (reader.Read())
                {
                    if (reader.GetString(1)?.ToLower() == "to")
                    {
                        startDate = reader.GetDateTime(0);
                        endDate = reader.GetDateTime(2);
                    }

                    if (IsNextLineTimesheet && !string.IsNullOrEmpty(reader.GetString(0)))
                    {
                        // Now you can get data from each sheet by its index or its "name"
                        var dataTable = result.Tables[0];

                        int j = 7;
                        double shift = 0;
                        for (int i = 1; i <= 7; i++)
                        {
                            shift = reader.GetValue(j - 3)?.ToString() == "12pm" ? 12 : 6;
                            var sd = startDate.AddHours(shift);
                            var rdEndDate = Convert.ToDouble(reader.GetValue(j));
                            if (rdEndDate != 0)
                            {
                                timesheets.Add(new Timesheet
                                {
                                    EmployeeId = reader.GetString(0),
                                    Surname = reader.GetString(1),
                                    Name = reader.GetString(2),
                                    IdNumber = reader.GetValue(3)?.ToString(),
                                    StartDate = sd,
                                    EndDate = sd.AddHours(rdEndDate),
                                    CreatedBy = 1, //1,31,35,36,43,44,53 we need to know what this maps to. 
                                    CreatedDate = DateTime.Now,
                                    UpdatedBy = 1, // same as created by
                                    UpdatedDate = DateTime.Now,
                                    TimeStamp = DateTime.Now,
                                    Deleted = null,
                                    Secterr = null, // NULL,- 2147483640,- 1342177274
                                    WorkflowId = null,
                                    Status = null,// NULL,Approved,Duplicate,Leave,New,NightShift,Normal,UnApproved
                                    CompanyId = null, // couple of companies
                                    PersonId = null,
                                    OpportunityId = null,
                                    OrderId = null,
                                    QuoteId = null, //99
                                    LeadId = null,
                                    CaseId = null,
                                    normalhrs = rdEndDate, //verify this
                                    overtimehrs = rdEndDate - 8, //anything over than 8 hours is overtime??
                                    phhrs = 0,//don't this
                                    nightshifthrs = null,
                                    sundayhrs = DateTime.Now.DayOfWeek.ToString() == "Sunday" ? rdEndDate : null,
                                    stage = null,
                                    siteid = Convert.ToInt32(fileUploadRequest.SiteId),
                                    prechargesheetid = null,
                                    breaktimehrs = null, // how to calculate
                                    normalhrstotal = null, // how to calculate
                                    normalhrstotal_CID = null, // how to calculate
                                    overtimehrstotal = null, // how to calculate
                                    overtimehrstotal_CID = null, // how to calculate
                                    position = null,
                                    shift = shift == 6 ? "NormalShift" : "NightShift",
                                    starttime = shift.ToString(),
                                    endtime = shift == 6 ? "2pm" : "8pm",
                                    approved = null, //Y,N
                                    placeholder1 = null,
                                    nightshifthrstotal = null,
                                    nightshifthrstotal_CID = null, //  how to get this
                                    employeeidsearch = 1, // how to get this
                                    positionsearch = 1,// hot to get this
                                    includedweekrun = null,
                                    invoiced = null, 
                                    workedhrs = rdEndDate,
                                    startdatesearch = null,
                                    enddatesearch = null,
                                    Source = "Import", //CRM, Payrun
                                    BatchNo = 1, // how to get this
                                    calculatedhrs = null, // hot to get this
                                    payrunid = 1, // how to get this
                                    week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday),
                                    timesheetrunid = 1,// how to get this
                                    invoiceid = null,
                                    calcnewtrainhrs = null, // how to get this
                                    invoicerunid = null,
                                    Override = null, //Y,N
                                    newweek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
                                }) ;
                            }
                            j += 4;
                            startDate = startDate.AddDays(1);
                        }
                        startDate = startDate.AddDays(-7);
                    }
                    else
                    {
                        IsNextLineTimesheet = false;

                    }
                    string getEndString = reader.GetValue(6)?.ToString()?.ToLower();
                    if (getEndString == "end")
                    {
                        IsNextLineTimesheet = true;
                    }
                }
            }
            //}
            return timesheets;
        }

    }
}
