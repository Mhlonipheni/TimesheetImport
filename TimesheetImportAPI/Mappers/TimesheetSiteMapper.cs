using TimesheetImport.TimesheetModels;
using TimesheetImportAPI.Models;

namespace TimesheetImportAPI.Mappers
{
    public static class TimesheetSiteMapper
    {
        public static List<TimeSheetSiteViewModel> Map(this List<TimesheetSite> model)
        {
            return model.Select(s => new TimeSheetSiteViewModel()
            {
                SiteId = s.SiteId,
                SiteName = s.SiteName
            }).ToList();
        }
    }
}
