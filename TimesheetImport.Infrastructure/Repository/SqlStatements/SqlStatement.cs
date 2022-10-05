namespace TimesheetImport.Infrastructure.Repository.SqlStatements
{
    public class SqlStatement
    {
        public const string GetTimesheetSites = @"SELECT [site_SiteID] ,[site_Name] FROM [dbo].[Site]";
    }
}
