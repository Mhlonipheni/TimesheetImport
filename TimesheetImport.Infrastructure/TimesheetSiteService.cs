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

        public async Task<TimesheetImportResult> ImportToTimesheets(FileUploadRequest fileUploadRequest)
        {
            using (RMSContext rms = new RMSContext())
            {
                var timesheests = TimesheetSiteMapper.FromFileToTimesheets(fileUploadRequest, rms);

                var result = await repository.SaveTimesheet(timesheests, rms).ConfigureAwait(false);

                return TimesheetSiteMapper.Map(result);

                //let's change this to  return some errors.
            }
        }
    }
}
