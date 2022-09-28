using ExcelDataReader;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure.Repository;
using TimesheetImport.Infrastructure.Repository.ModelMappings;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.TimesheetModels;

namespace TimesheetImport.Infrastructure
{
    public class TimesheetSiteService : ITimesheetSiteService
    {
        private readonly ITimesheetSiteRepository repository;
        public TimesheetSiteService(ITimesheetSiteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<TimesheetSite>> GetTimesheetSites()
        {
            var result = await repository.GetTimesheetSites().ConfigureAwait(false);
            return TimesheetSiteMapper.MapFromTimesheetSite(result);
        }
        public async Task<List<Timesheet>> FromFileToTimesheets(FileUploadRequest fileUploadRequest)
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
                                        Start = sd,//Convert.ToDateTime(reader.GetString(j)),
                                        End = sd.AddHours(rdEndDate)//Convert.ToDateTime(reader.GetString(j))
                                    });
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
