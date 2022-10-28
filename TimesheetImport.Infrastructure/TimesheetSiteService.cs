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
            int secterr = -2147483640;
            using (RMSContext rms = new RMSContext())
            {
                //get id and pass it to SaveTimesheeet, 
                var timesheetRunId = repository.CreateHeader(fileUploadRequest.SiteId, secterr, rms);

                var timesheests = TimesheetSiteMapper.FromFileToTimesheets(fileUploadRequest, rms, timesheetRunId);               

                var result = await repository.SaveTimesheet(timesheests, rms).ConfigureAwait(false);

                return TimesheetSiteMapper.Map(result);

                //let's change this to  return some errors.
            }
        }
    }
}
