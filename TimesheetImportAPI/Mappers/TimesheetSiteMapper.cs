using TimesheetImport.TimesheetModels;
using TimesheetImportAPI.Models;
using TimesheetImportResult = TimesheetImportAPI.Models.TimesheetImportResult;

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

        public static TimesheetImportResult Map(TimesheetImport.TimesheetModels.TimesheetImportResult model)
        {
            var result = new TimesheetImportResult();
            result.Success = model.Success;
            result.Notifications.AddRange(model.Notifications.Select(n => new Models.Notification() { LineNumber = n.LineNumber, Message = n.Message }));
            return result;
        }
    }
}
