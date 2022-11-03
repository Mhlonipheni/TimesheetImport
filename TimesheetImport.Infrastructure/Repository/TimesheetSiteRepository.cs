using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure.Repository.Base;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.Infrastructure.Repository.SqlStatements;

namespace TimesheetImport.Infrastructure.Repository
{
    public class TimesheetSiteRepository : RepositoryBase, ITimesheetSiteRepository
    {
        public TimesheetSiteRepository(IOptions<InfrastructureOptions> options) : base(options)
        {

        }

        public async Task<List<TimesheetSiteModel>> GetTimesheetSites()
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var result = await conn.QueryAsync<TimesheetSiteModel>(SqlStatement.GetTimesheetSites).ConfigureAwait(false);
                return result.ToList();
            }
        }

        public async Task<TimesheetImportResultModel> SaveTimesheet(List<Timesheet> timesheets, RMSContext rms)
        {
            rms.Timesheets.AddRange(timesheets);
            var result = await rms.SaveChangesAsync().ConfigureAwait(false);
            var errorMessage = string.Empty;
            if (result != timesheets.Count)
            {
                errorMessage = "Import Timesheet failed";
            }
            return new TimesheetImportResultModel()
            {
                Success = result > 0,
                Notifications = new List<Notification>
                {
                    new Notification()
                    {
                        ErrorMessage = errorMessage,
                    }
                }
                     
                    
            };
        }
    }
}
