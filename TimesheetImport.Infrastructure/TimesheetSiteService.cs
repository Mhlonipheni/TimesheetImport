using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<TimesheetImportResult> ImportToTimesheets(FileUploadRequest fileUploadRequest, RMSContext rMSContext)
        {
            using (rMSContext)
            {
                var result = TimesheetSiteMapper.FromFileToTimesheets(fileUploadRequest, rMSContext);
                //
                var saveResult = new TimesheetImportResultModel();
                if (!result.Item2.Any())
                {
                    saveResult = await repository.SaveTimesheet(result.Item1, rMSContext).ConfigureAwait(false);
                }

                return TimesheetSiteMapper.Map(saveResult, result.Item2);

            }
        }
    }
}
