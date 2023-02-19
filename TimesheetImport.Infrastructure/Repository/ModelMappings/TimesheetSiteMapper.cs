﻿using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.TimesheetModels;
using Notification = TimesheetImport.TimesheetModels.Notification;
using Severity = TimesheetImport.TimesheetModels.Severity;
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

        public static List<Timesheet> MapToTimesheets(List<TimesheetDetail> timesheetDetails, int timesheetRunId)
        {
            var timesheets = new List<Timesheet>();

            foreach (var timesheetDetail in timesheetDetails)
            {
                var timesheet = new Timesheet
                {
                    TimeCreatedBy = timesheetDetail.TimeUpdatedBy,
                    TimeCreatedDate = timesheetDetail.TimeCreatedDate,
                    TimeUpdatedBy = timesheetDetail.TimeUpdatedBy,
                    TimeUpdatedDate = timesheetDetail.TimeUpdatedDate,
                    TimeTimeStamp = timesheetDetail.TimeTimeStamp,
                    TimeSecterr = timesheetDetail.TimeSecterr,
                    TimeStatus = timesheetDetail.TimeStatus,
                    TimeCompanyId = timesheetDetail.TimeCompanyId,
                    TimeEmployeeid = timesheetDetail.TimeEmployeeid,
                    TimeStartdate = timesheetDetail.TimeStartdate,
                    TimeEnddate = timesheetDetail.TimeEnddate,
                    TimeNormalhrs = timesheetDetail.TimeNormalhrs,
                    TimeNightshifthrs = timesheetDetail.TimeNightshifthrs,
                    TimeSundayhrs = timesheetDetail.TimeSundayhrs,
                    TimeSiteid = timesheetDetail.TimeSiteid,
                    TimeBreaktimehrs = timesheetDetail.TimeBreaktimehrs,
                    TimePosition = timesheetDetail.TimePosition,
                    TimeShift = timesheetDetail.TimeShift,
                    TimeStarttime = timesheetDetail.TimeStarttime,
                    TimeEndtime = timesheetDetail.TimeEndtime,
                    TimeWorkedhrs = timesheetDetail.TimeWorkedhrs,
                    TimeSource = timesheetDetail.TimeSource,
                    TimeBatchNo = timesheetDetail.TimeBatchNo,
                    TimeWeek = timesheetDetail.TimeWeek,
                    TimeTimesheetrunid = timesheetRunId,
                    TimeNewweek = timesheetDetail.TimeNewweek,
                };
                timesheets.Add(timesheet);
            }

            return timesheets;
        }
        public static Tuple<List<TimesheetDetail>, List<Notification>> FromFileToTimesheets(FileUploadRequest fileUploadRequest, RMSContext rms)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            var jobName = string.Empty;
            var timesheets = new List<TimesheetDetail>();

            int userId = 1;//move config
            var batchNo = 0;
            int secterr = -2147483640;
            int timeBreaktimehrs = 1;
            Decimal timePhhrs = 0;
            Decimal timeSundayhrs = 0;
            var nightShiftStart = 0.0;
            var nightShiftEnd = 0.0;
            var tNormalHours = 0.0;
            var tNightHours = 0.0;
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

                                int j = 4;
                                int i = 7;
                                double shift = 0;
                                for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
                                {
                                    //Read CRM inputs
                                    Employee employee = rms.Employees.Where(w => w.EmplIdnumber == reader.GetValue(3).ToString() || w.EmplName == reader.GetValue(0).ToString()).FirstOrDefault();
                                    NewProduct jobPosition = rms.NewProducts.Where(w => w.ProdName == jobName).FirstOrDefault();
                                    Site site = rms.Sites.Where(w => w.SiteSiteId == fileUploadRequest.SiteId).FirstOrDefault();
                                    Rate rate = rms.Rates.Where(w => w.RateSiteid == fileUploadRequest.SiteId).FirstOrDefault();
                                    int holidayCount = rms.HolidaySetItems.Where(w => w.HsitHsetHolidaySetId == site.SitePhset && w.HsitCreatedDate.Value.Date == startDate.Date).Count();

                                    //Read Excel inputs
                                    string pattern = @"(\d+)(\D+)";
                                    if (!string.IsNullOrEmpty(reader.GetString(j)))
                                    {
                                        var workedHrs = Convert.ToDouble(reader.GetValue(i));
                                        Match match = Regex.Match(reader.GetString(j)?.ToString(), pattern);
                                        shift = Convert.ToDouble(match.Groups[1].Value);
                                        var startTime = reader.GetDateTime(j + 1).TimeOfDay;
                                        var endTime = reader.GetDateTime(j + 2).TimeOfDay;

                                        var sd = date.Add(startTime);
                                        var ed = sd.AddHours(workedHrs);

                                        //Calc fields
                                        nightShiftStart = (site.SiteNsbceatype == null || site.SiteNsbceatype.ToLower() == "site") ?
                                                           site.SiteNsbceashiftstart != null ? site.SiteNsbceashiftstart.Value : 18 : rate.RateNsbceashiftstart != null ? rate.RateNsbceashiftstart.Value : 18;

                                        nightShiftEnd = (site.SiteNsbceatype == null || site.SiteNsbceatype.ToLower() == "site") && (site.SiteNsbceashiftend != null) ?
                                                         site.SiteNsbceashiftend != null ? site.SiteNsbceashiftend.Value : 6 : rate.RateNsbceashiftend != null ? rate.RateNsbceashiftend.Value : 6;

                                        var IsNormalShift = shift > nightShiftEnd && shift < nightShiftStart;

                                        Tuple<double, double> hours = CalculateHours(sd, ed, nightShiftStart, nightShiftEnd);

                                        if (sd.DayOfWeek == DayOfWeek.Sunday)
                                        {
                                            timeSundayhrs = Convert.ToDecimal(hours.Item1) + Convert.ToDecimal(hours.Item2);
                                        }
                                        else if (holidayCount > 0)
                                        {
                                            timePhhrs = Convert.ToDecimal(hours.Item1) + Convert.ToDecimal(hours.Item2);
                                        }
                                        else
                                        {
                                            tNormalHours = hours.Item1;
                                            tNightHours = hours.Item2;
                                        }

                                        var timesheet = new TimesheetDetail
                                        {
                                            TimeCreatedBy = userId, //1,31,35,36,43,44,53 we need to know what this maps to.
                                            TimeCreatedDate = DateTime.Now,
                                            TimeUpdatedBy = userId, // same as created by
                                            TimeUpdatedDate = DateTime.Now,
                                            TimeTimeStamp = DateTime.Now,
                                            TimeSecterr = employee?.EmplSecterr, // NULL,- 2147483640,- 1342177274
                                            TimeStatus = "New",// NULL,Approved,Duplicate,Leave,New,NightShift,Normal,UnApproved
                                            TimeCompanyId = site.SiteCompanyId, // couple of companies in DB
                                            TimeEmployeeid = employee?.EmplEmployeeId,//Convert.(reader.GetValue(3)), //come back
                                            TimeStartdate = sd,
                                            TimeEnddate = ed,
                                            TimeNormalhrs = Convert.ToDecimal(tNormalHours),
                                            TimeOvertimehrs = null, //anything over than 8 hours is overtime??//comment out
                                            TimePhhrs = timePhhrs,//don't know this
                                            TimeNightshifthrs = Convert.ToDecimal(tNightHours),
                                            TimeSundayhrs = timeSundayhrs,
                                            TimeSiteid = Convert.ToInt32(fileUploadRequest?.SiteId),
                                            TimeBreaktimehrs = timeBreaktimehrs, // how to calculate
                                            TimePosition = jobPosition?.ProdProductId,
                                            TimeShift = IsNormalShift ? "NormalShift" : "NightShift",
                                            TimeStarttime = startTime.ToString().Replace(":", "").Substring(0, 4),
                                            TimeEndtime = endTime.ToString().Replace(":", "").Substring(0, 4),
                                            TimeWorkedhrs = Convert.ToDecimal(workedHrs), // normal worked hours.
                                            TimeSource = "Import", //CRM, Payrun
                                            TimeBatchNo = batchNo, // how to get this
                                            TimeWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday),
                                            TimeNewweek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) + 1,
                                        };

                                        var crmTimeSheet = rms.Timesheets.Where(w => w.TimeEmployeeid == timesheet.TimeEmployeeid && w.TimeStartdate == timesheet.TimeStartdate && w.TimeShift == timesheet.TimeShift && w.TimeDeleted == null).FirstOrDefault();

                                        if (crmTimeSheet != null)
                                        {
                                            //notifications.Add(new Notification() { LineNumber = "", ErrorMessage = "Duplicate record in CRM for Employee: " + employee.EmplName + " for date:" + sd.ToShortDateString() });
                                            //return Tuple.Create(timesheets, notifications);
                                        }

                                        if (workedHrs > 0)
                                        {
                                            timesheets.Add(timesheet);
                                        }
                                    }
                                    j += 4;
                                    i += 4;
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
                                Message = ex.Message,
                                Severity = Severity.Critical
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                notifications.Add(new Notification() { LineNumber = "", Message = ex.Message, Severity = Severity.Critical });
            }
            return Tuple.Create(timesheets, notifications); 
        }

        public static TimesheetImportResult Map(List<TimesheetDetail> timesheets, List<Notification> model)
        {
            
            return new TimesheetImportResult()
            {
               TimesheetDetails = timesheets,
                Notifications = model
            };
        }

        private static Tuple<double, double> CalculateHours(DateTime start, DateTime end, double nightShiftStart, double nightShiftEnd)
        {
            double normalHours = 0.0;
            double nightHours = 0.0;
            DateTime current = start;

            end = end.AddHours(1);

            while (current < end)
            {
                if (current.Hour >= nightShiftEnd && current.Hour < nightShiftStart)
                {                   
                    normalHours += (current.Hour == nightShiftStart) ? current.Minute / 60.0 : 1;
                }
                else
                {
                    nightHours += (current.Hour == nightShiftEnd) ? current.Minute / 60.0 : 1;
                }
                current = current.AddHours(1);
            }
            normalHours += (normalHours > 0) ? -1 : 0;
            nightHours += (normalHours <= 0) ? -1 : 0;
            return Tuple.Create(normalHours, nightHours);
        }
    }
}
