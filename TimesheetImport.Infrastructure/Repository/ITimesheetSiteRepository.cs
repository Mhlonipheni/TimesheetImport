using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure.Repository.Models;

namespace TimesheetImport.Infrastructure.Repository
{
    public interface ITimesheetSiteRepository
    {
        Task<List<TimesheetSiteModel>> GetTimesheetSites();       
        Task SaveTimesheet(List<Timesheet> timesheets);       
    }
}
