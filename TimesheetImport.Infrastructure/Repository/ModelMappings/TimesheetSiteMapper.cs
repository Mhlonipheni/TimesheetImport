using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.TimesheetModels;
using Site = TimesheetImport.Infrastructure.Repository.Models.Site;

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

        public static List<Timesheet> FromFileToTimesheets(FileUploadRequest fileUploadRequest, RMSContext rms)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            var jobName = string.Empty;
            var timesheets = new List<Timesheet>();

            int userId = 1;
            var batchNo = 0;
            int secterr = -2147483640;
            var lasttimesheet = rms.Timesheets.OrderByDescending(o => o.TimeBatchNo).FirstOrDefault();            

            if (lasttimesheet == null || lasttimesheet.TimeBatchNo.HasValue == false)
                batchNo = 1;
            else
                batchNo = lasttimesheet.TimeBatchNo.Value + 1; 

            MemoryStream newStr = new MemoryStream(fileUploadRequest.File.ToArray());

            using (var reader = ExcelReaderFactory.CreateReader(newStr))
            {
                var result = reader.AsDataSet();
                bool IsNextLineTimesheet = false;
                while (reader.Read())
                {
                    if (reader.GetString(1)?.ToLower() == "to")
                    {
                        startDate = reader.GetDateTime(0);
                        endDate = reader.GetDateTime(2);
                        jobName = reader.GetString(3);
                    }

                    if (IsNextLineTimesheet && !string.IsNullOrEmpty(reader.GetString(0)))
                    {
                        // Now you can get data from each sheet by its index or its "name"
                        var dataTable = result.Tables[0];

                        int j = 7;
                        double shift = 0;
                        for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
                        {
                            //using id number
                            Employee employee = rms.Employees.Where(w => w.EmplIdnumber == reader.GetValue(3).ToString() || w.EmplName == reader.GetValue(0).ToString()).FirstOrDefault();
                            NewProduct jobPosition = rms.NewProducts.Where(w => w.ProdName == jobName).FirstOrDefault();
                            Site site = rms.Sites.Where(w => w.SiteSiteId == fileUploadRequest.SiteId).FirstOrDefault();
                            Company company = rms.Companies.Where(w => w.CompCompanyId == site.SiteCompanyId).FirstOrDefault();

                            shift = reader.GetValue(j - 3)?.ToString() == "12pm" ? 12 : 6;
                            var sd = date.AddHours(shift);
                            var rdEndDate = Convert.ToDouble(reader.GetValue(j));
                            if (rdEndDate > 0)
                            {
                                timesheets.Add(new Timesheet
                                {
                                    TimeCreatedBy = userId, //1,31,35,36,43,44,53 we need to know what this maps to.
                                    TimeCreatedDate = DateTime.Now,
                                    TimeUpdatedBy = userId, // same as created by
                                    TimeUpdatedDate = DateTime.Now,
                                    TimeTimeStamp = DateTime.Now,
                                    TimeDeleted = null,
                                    TimeSecterr = employee?.EmplSecterr, // NULL,- 2147483640,- 1342177274
                                    TimeName = reader.GetString(0),
                                    TimeWorkflowId = null,
                                    TimeStatus = "New",// NULL,Approved,Duplicate,Leave,New,NightShift,Normal,UnApproved
                                    TimeCompanyId = company?.CompCompanyId, // couple of companies in DB
                                    TimePersonId = null,
                                    TimeOpportunityId = null,
                                    TimeOrderId = null,
                                    TimeQuoteId = null,
                                    TimeLeadId = null,
                                    TimeCaseId = null,
                                    TimeEmployeeid = employee?.EmplEmployeeId,//Convert.(reader.GetValue(3)), //come back
                                    TimeStartdate = sd,
                                    TimeEnddate = sd.AddHours(rdEndDate),
                                    TimeNormalhrs = Convert.ToDecimal(rdEndDate),
                                    TimeOvertimehrs = Convert.ToDecimal(rdEndDate) - 8, //anything over than 8 hours is overtime??
                                    TimePhhrs = 0,//don't know this
                                    TimeNightshifthrs = null,
                                    TimeSundayhrs = DateTime.Now.DayOfWeek.ToString() == "Sunday" ? Convert.ToDecimal(rdEndDate) : null,
                                    TimeStage = String.Empty,
                                    TimeSiteid = Convert.ToInt32(fileUploadRequest?.SiteId),
                                    TimePrechargesheetid = null,
                                    TimeBreaktimehrs = null, // how to calculate
                                    TimeNormalhrstotal = null,
                                    TimeNormalhrstotalCid = null,
                                    TimeOvertimehrstotal = null,
                                    TimeOvertimehrstotalCid = null,
                                    TimePosition = jobPosition?.ProdProductId,
                                    TimeShift = shift == 6 ? "NormalShift" : "NightShift",
                                    TimeStarttime = shift.ToString(),
                                    TimeEndtime = shift == 6 ? "2pm" : "8pm",
                                    TimeApproved = null, //Y,N
                                    TimePlaceholder1 = null,
                                    TimeNightshifthrstotal = null,
                                    TimeNightshifthrstotalCid = null,
                                    TimeEmployeeidsearch = null,
                                    TimePositionsearch = null,
                                    TimeIncludedweekrun = string.Empty,
                                    TimeInvoiced = string.Empty,
                                    TimeWorkedhrs = Convert.ToDecimal(rdEndDate),
                                    TimeStartdatesearch = null,
                                    TimeEnddatesearch = null,
                                    TimeSource = "Import", //CRM, Payrun
                                    TimeBatchNo = batchNo, // how to get this
                                    TimeCalculatedhrs = null,
                                    TimePayrunid = Convert.ToInt32(employee?.EmplPayrun), // how to get this
                                    TimeWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday),
                                    TimeTimesheetrunid = 1,// how to get this
                                    TimeInvoiceid = null,
                                    TimeCalcnewtrainhrs = null,
                                    TimeInvoicerunid = null,
                                    TimeOverride = null, //Y,N
                                    TimeNewweek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) + 1,
                                });
                            }
                            j += 4;
                        }
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
            return timesheets;
        }

        public static TimesheetImportResult Map(TimesheetImportResultModel timesheetImportResult)
        {
            return new TimesheetImportResult()
            {
                Success = timesheetImportResult.Success,
                //Notifications = new List<Notification>
                //{
                //    new Notification()
                //    {
                //        Message = timesheetImportResult.Errors.FirstOrDefault()
                //    }
                //}
            };
        }

    }
}
