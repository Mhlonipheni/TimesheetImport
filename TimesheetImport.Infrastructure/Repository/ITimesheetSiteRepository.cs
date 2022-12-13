using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure.Repository.Models;

namespace TimesheetImport.Infrastructure.Repository
{
    public interface ITimesheetSiteRepository
    {
        Task<List<TimesheetSiteModel>> GetTimesheetSites();
        Task<TimesheetImportResultModel> SaveTimesheet(List<Timesheet> timesheets, RMSContext rms);
        int CreateHeader(int siteId, int secterr, RMSContext rms);
    }
}
