using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetImport.Infrastructure.Repository.SqlStatements
{
    public class SqlStatement
    {
        public const string GetTimesheetSites = @"SELECT [site_SiteID] ,[site_Name] FROM [dbo].[Site]";
    }
}
