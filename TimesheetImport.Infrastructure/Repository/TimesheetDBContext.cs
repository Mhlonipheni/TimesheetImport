using System.Data.Entity;
using TimesheetImport.Infrastructure.Repository.Models;

namespace TimesheetImport.Infrastructure.Repository
{
    internal class TimesheetDBContext : DbContext
    {
            public TimesheetDBContext(string conn) : base(conn)
            {

            }

            public DbSet<Timesheet> Timesheets { get; set; }        
    }
}
