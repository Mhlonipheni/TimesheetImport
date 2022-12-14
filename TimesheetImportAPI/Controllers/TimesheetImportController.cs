using Microsoft.AspNetCore.Mvc;
using TimesheetImport.Infrastructure;
using TimesheetImportAPI.Models;
using TimesheetImportAPI.Mappers;

namespace TimesheetImportAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TimesheetImportController : Controller
    {
        private readonly ITimesheetSiteService timesheetSiteService;
        public TimesheetImportController(ITimesheetSiteService timesheetSiteService)
        {
            this.timesheetSiteService = timesheetSiteService;

        }
        [HttpGet]
        [Produces(typeof(List<TimeSheetSiteViewModel>))]
        public async Task<ActionResult<List<TimeSheetSiteViewModel>>> GetTimesheetSites()
        {
            var result = await timesheetSiteService.GetTimesheetSites();
            return result.Map();
        }

        [HttpPost]
        [Produces(typeof(TimesheetImportResult))]
        public async Task<ActionResult<TimesheetImportResult>> Import([FromForm] FileUploadRequest fileUploadRequest)
        {
            var fileRequest = fileUploadRequest.Map();

            var result  = await timesheetSiteService.ImportToTimesheets(fileRequest).ConfigureAwait(false);
          
            TimesheetImportResult timesheetImportResult = new TimesheetImportResult()
            {
                Success = result.Success,
                Notifications = new List<Notification>()
                {
                    new Notification()
                    {
                        Message = result.Notifications.First().Message ?? null
                    }
                }

            };
            return timesheetImportResult;
        }
    }
}
