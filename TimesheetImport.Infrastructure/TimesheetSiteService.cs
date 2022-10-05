using System;
using System.Collections.Generic;
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

        public async Task ImportToTimesheets(FileUploadRequest fileUploadRequest)
        {
            try
            {
                using (RMSContext rms = new RMSContext())
                {
                    var timesheests = TimesheetSiteMapper.FromFileToTimesheets(fileUploadRequest, rms);

                    await repository.SaveTimesheet(timesheests, rms).ConfigureAwait(false);

                    //let's change this to  return some errors.
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Message: " + ex.Message);
                //whatever we need to do with the error 
            }
        }
    }
}
