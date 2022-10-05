using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetImport.TimesheetModels;
using TimesheetImport.Infrastructure.Repository.Models;

namespace TimesheetImport.Infrastructure
{
    public interface ITimesheetSiteService
    {
        Task<List<TimesheetSite>> GetTimesheetSites();
        Task<TimesheetImportResult> ImportToTimesheets(FileUploadRequest fileUploadRequest);
    }
}
