﻿using ExcelDataReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.TimesheetModels;
using Notification = TimesheetImport.Infrastructure.Repository.Models.Notification;
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

        public static Tuple<List<Timesheet>, List<Notification>> FromFileToTimesheets(FileUploadRequest fileUploadRequest, RMSContext rms, int timesheetRunId)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            var jobName = string.Empty;
            var timesheets = new List<Timesheet>();

            int userId = 1;//move config
            var batchNo = 0;
            int secterr = -2147483640;
            int timeBreaktimehrs = 1;
            Decimal timePhhrs = 0;
            Decimal timeSundayhrs = 0;
            var notifications = new List<Notification>();
            try
            {


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
                    int lineNumber = 0;
                    while (reader.Read())
                    {
                        lineNumber++;
                        try
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
                                    Rate rate = rms.Rates.Where(w => w.RateSiteid == fileUploadRequest.SiteId && w.RateEmployeeid == employee.EmplEmployeeId).FirstOrDefault();
                                    //Company company = rms.Companies.Where(w => w.CompCompanyId == site.SiteCompanyId).FirstOrDefault();
                                    int holidayCount = rms.HolidaySetItems.Where(w => w.HsitHsetHolidaySetId == site.SitePhset && w.HsitCreatedDate.Value.Date == startDate.Date).Count();

                                    //shift = reader.GetValue(j - 3)?.ToString() == "12pm" ? 12 : 6;


                                    var ratesConfigStartNightShift = site.SiteNstarttime.Value;
                                    var ratesConfigEndNightShift = site.SiteNendtime.Value;
                                    string pattern = @"(\d+)(\D+)";
                                    Match match = Regex.Match(reader.GetValue(j - 3)?.ToString(), pattern);
                                    shift = Convert.ToDouble(match.Groups[1].Value);
                                    string stringPart = match.Groups[2].Value;





                                    var sd = date.AddHours(shift);
                                    var ed = sd.AddHours(8);
                                    var normalHrs = Convert.ToDecimal(reader.GetValue(j));

                                    if (site.SiteCity == "Site")
                                    {
                                        var siteConfigStartNightShift = site.SiteNstarttime.Value;
                                        var siteConfigEndNightShift = site.SiteNendtime.Value;

                                        TimeSpan tsStartTest = TimeSpan.Parse("4");
                                        TimeSpan tsStart = TimeSpan.Parse("04:00");
                                        TimeSpan tsEnd = TimeSpan.Parse("13:00");

                                        TimeSpan normalShiftStart = TimeSpan.Parse("06:00");
                                        TimeSpan normalShiftEnd = TimeSpan.Parse("18:00");
                                        TimeSpan nightShiftStart = TimeSpan.Parse("18:00");
                                        TimeSpan nightShiftEnd = TimeSpan.Parse("06:00");

                                        TimeSpan normalHours = CalculateNormalHours(tsStart, tsEnd, normalShiftStart, normalShiftEnd);
                                        TimeSpan overtimeHours = CalculateOvertimeHours(tsStart, tsEnd, normalShiftStart, normalShiftEnd, nightShiftStart, nightShiftEnd);

                                        Console.WriteLine("Normal hours worked: " + normalHours.TotalHours);
                                        Console.WriteLine("Overtime hours worked: " + overtimeHours.TotalHours);

                                        Console.ReadLine();

                                        //if (date.Hour >= 18 || ed.Hour < 6)
                                        //{
                                        //    nightShiftHours += (end - start).TotalHours;
                                        //}
                                        //else
                                        //{
                                        //    dayShiftHours += (end - start).TotalHours;
                                        //}
                                    }

                                    if (shift == 6)
                                    {
                                        if (holidayCount > 0)
                                        {
                                            timePhhrs = normalHrs - timeBreaktimehrs;
                                        }
                                        if (date.DayOfWeek == DayOfWeek.Sunday)
                                        {
                                            timeSundayhrs = normalHrs - timeBreaktimehrs;
                                        }

                                    }
                                    else if (shift == 12)
                                    {
                                        if (holidayCount > 0)
                                        {
                                            timePhhrs = normalHrs - timeBreaktimehrs;
                                        }
                                        if (date.DayOfWeek == DayOfWeek.Sunday)
                                        {
                                            timeSundayhrs = normalHrs - timeBreaktimehrs;
                                        }
                                    }

                                    if (normalHrs > 0)
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
                                            TimeName = null,
                                            TimeWorkflowId = null,
                                            TimeStatus = "New",// NULL,Approved,Duplicate,Leave,New,NightShift,Normal,UnApproved
                                            TimeCompanyId = site.SiteCompanyId, // couple of companies in DB
                                            TimePersonId = null,
                                            TimeOpportunityId = null,
                                            TimeOrderId = null,
                                            TimeQuoteId = null,
                                            TimeLeadId = null,
                                            TimeCaseId = null,
                                            TimeEmployeeid = employee?.EmplEmployeeId,//Convert.(reader.GetValue(3)), //come back
                                            TimeStartdate = sd,
                                            TimeEnddate = sd.AddHours(Convert.ToDouble(normalHrs)),
                                            TimeNormalhrs = normalHrs,
                                            TimeOvertimehrs = null, //anything over than 8 hours is overtime??//comment out
                                            TimePhhrs = timePhhrs,//don't know this
                                            TimeNightshifthrs = Convert.ToDecimal(normalHrs),
                                            TimeSundayhrs = timeSundayhrs,
                                            TimeStage = String.Empty,
                                            TimeSiteid = Convert.ToInt32(fileUploadRequest?.SiteId),
                                            TimePrechargesheetid = null,
                                            TimeBreaktimehrs = timeBreaktimehrs, // how to calculate
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
                                            TimeWorkedhrs = Convert.ToDecimal(normalHrs), // normal worked hours.
                                            TimeStartdatesearch = null,
                                            TimeEnddatesearch = null,
                                            TimeSource = "Import", //CRM, Payrun
                                            TimeBatchNo = batchNo, // how to get this
                                            TimeCalculatedhrs = null,
                                            TimePayrunid = null, // how to get this
                                            TimeWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday),
                                            TimeTimesheetrunid = timesheetRunId,// get from header creation
                                            TimeInvoiceid = null,
                                            TimeCalcnewtrainhrs = null,
                                            TimeInvoicerunid = null,
                                            TimeOverride = null, //Y,N
                                            TimeNewweek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) + 1,
                                        }); ;
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
                        catch (Exception ex)
                        {
                            notifications.Add(new Notification()
                            {
                                LineNumber = lineNumber.ToString(),
                                ErrorMessage = ex.Message
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                notifications.Add(new Notification() { LineNumber = "", ErrorMessage = ex.Message });
            }
            return Tuple.Create(timesheets, notifications); ;
        }

        public static TimesheetImportResult Map(TimesheetImportResultModel timesheetImportResult, List<Notification> model)
        {
            var notifications = new List<TimesheetImport.TimesheetModels.Notification>();
            if (model != null && model.Any())
            {

                notifications.AddRange(model.Select(n => new TimesheetModels.Notification()
                {
                    LineNumber = n.LineNumber,
                    Message = n.ErrorMessage
                }));

                foreach (var notification in model)
                {

                }
            }
            return new TimesheetImportResult()
            {
                Success = timesheetImportResult.Success,
                Notifications = notifications
            };
        }

        private static TimeSpan CalculateNormalHours(TimeSpan start, TimeSpan end, TimeSpan normalStart, TimeSpan normalEnd)
        {
            if (start <= normalStart && end <= normalStart)
                return TimeSpan.Zero;
            else if (start >= normalEnd && end >= normalEnd)
                return TimeSpan.Zero;
            else if (start >= normalStart && end <= normalEnd)
                return end - start;
            else if (start <= normalStart && end >= normalEnd)
                return normalEnd - normalStart;
            else if (start <= normalStart && end <= normalEnd)
                return end - normalStart;
            else
                return normalEnd - start;
        }

        private static TimeSpan CalculateOvertimeHours(TimeSpan start, TimeSpan end, TimeSpan normalStart, TimeSpan normalEnd, TimeSpan nightStart, TimeSpan nightEnd)
        {
            if (start <= normalStart && end <= normalStart)
                return end - start;
            else if (start >= normalEnd && end >= normalEnd)
                return end - start;
            else if (start >= normalStart && end <= normalEnd)
                return TimeSpan.Zero;
            else if (start <= normalStart && end >= normalEnd)
                return TimeSpan.Zero;
            else if (start <= normalStart && end <= normalEnd)
                return normalEnd - end;
            else if (start <= nightStart && end <= nightEnd)
                return TimeSpan.Zero;
            else if (start >= nightEnd && end >= nightEnd)
                return TimeSpan.Zero;
            else if (start >= nightStart && end <= nightEnd)
                return end - start;
            else
                return nightEnd - start + end - normalStart;
        }
    }
}
