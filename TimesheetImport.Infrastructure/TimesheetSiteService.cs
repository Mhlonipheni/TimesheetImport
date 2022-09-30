using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure.Repository;
using TimesheetImport.Infrastructure.Repository.ModelMappings;
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
            var timesheests = TimesheetSiteMapper.FromFileToTimesheets(fileUploadRequest);

            await repository.SaveTimesheet(timesheests).ConfigureAwait(false);

            //let's change this to return some errors.
        }
    }
}
