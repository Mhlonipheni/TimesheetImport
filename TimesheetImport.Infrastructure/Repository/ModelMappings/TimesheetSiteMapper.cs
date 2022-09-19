using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.TimesheetModels;

namespace TimesheetImport.Infrastructure.Repository.ModelMappings
{
    public static class TimesheetSiteMapper
    {
        public static List<TimesheetSite> MapFromTimesheetSite(List<TimesheetSiteModel> model)
        {
            return model.Select(s => new TimesheetSite()
            {
                SiteId = s.site_SiteID,
                SiteName = s.site_Name
            }).ToList();
        }
    }
}
