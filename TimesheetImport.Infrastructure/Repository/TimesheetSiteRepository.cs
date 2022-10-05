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

        public async Task SaveTimesheet(List<Timesheet> timesheets, RMSContext rms)
        {
            rms.Timesheets.AddRange(timesheets);
            await rms.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
