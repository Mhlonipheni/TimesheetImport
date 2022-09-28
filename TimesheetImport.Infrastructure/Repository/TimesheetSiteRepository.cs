using Dapper;
using ExcelDataReader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure.Repository.Base;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.Infrastructure.Repository.SqlStatements;
using TimesheetImport.TimesheetModels;

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
        
        public async Task SaveTimesheet(List<Timesheet> timesheets)
        {
            using (var ctx = new TimesheetDBContext(Connection.ConnectionString))
            {
                //var s = new Timesheet() { Name = "Sim" };
                ctx.Timesheets.AddRange(timesheets);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
