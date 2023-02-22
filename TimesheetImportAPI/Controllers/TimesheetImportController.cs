using Microsoft.AspNetCore.Mvc;
using TimesheetImport.Infrastructure;
using TimesheetImportAPI.Models;
using TimesheetImportAPI.Mappers;
using TimesheetImport.Infrastructure.Repository.Models;
using TimesheetImport.TimesheetModels;

namespace TimesheetImportAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TimesheetImportController : Controller
    {
        private readonly ITimesheetSiteService timesheetSiteService;
        private readonly RMSContext rMSContext;
        public TimesheetImportController(ITimesheetSiteService timesheetSiteService, RMSContext rMSContext)
        {
            this.timesheetSiteService = timesheetSiteService;
            this.rMSContext = rMSContext;

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
        public async Task<ActionResult<TimesheetImportResult>> Import([FromForm] TimesheetImportAPI.Models.FileUploadRequest fileUploadRequest)
        {
            var fileRequest = fileUploadRequest.Map();

            var result  = await timesheetSiteService.ImportToTimesheets(fileRequest, rMSContext).ConfigureAwait(false);
           
            return result;
        }

        [HttpPost]
        [Produces(typeof(TimesheetImportConfirmationResult))]
        public async Task<ActionResult<TimesheetImportConfirmationResult>> ConfirmImport([FromBody] List<TimesheetDetail> timesheetDetails)
        {

            var result = await timesheetSiteService.ConfirmImportToTimesheets(timesheetDetails, rMSContext).ConfigureAwait(false);

            return result;
        }
    }
}
