using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.TimesheetModels;

namespace TimesheetImport.Infrastructure
{
    public interface ITimesheetSiteService
    {
        Task<List<TimesheetSite>> GetTimesheetSites();
        Task<TimesheetImportResult> ImportToTimesheets(FileUploadRequest fileUploadRequest, RMSContext rMSContext);        
    }
}
