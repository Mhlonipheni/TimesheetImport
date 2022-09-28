using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetImport.Infrastructure;
using TimesheetImportAPI.Models;
using TimesheetImportAPI.Mappers;
using TimesheetImport.Infrastructure.Repository;

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
            // call service method here taking in fileRequest


            //this return the POCO object. 
            await timesheetSiteService.ImportToTimesheets(fileRequest).ConfigureAwait(false);

            //call the repo to save using EF6



            TimesheetImportResult timesheetImportResult = new TimesheetImportResult()
            {
                Success = true,
                Notifications = new List<Notification>()

            };
            return await Task.FromResult(timesheetImportResult).ConfigureAwait(false);
        }
    }
}
