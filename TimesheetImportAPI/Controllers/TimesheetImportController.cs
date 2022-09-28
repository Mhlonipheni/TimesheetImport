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
        private readonly ITimesheetSiteRepository repository;
        public TimesheetImportController(ITimesheetSiteService timesheetSiteService)
        {
            this.timesheetSiteService = timesheetSiteService;
            this.repository = repository;

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
            var result = await timesheetSiteService.FromFileToTimesheets(fileRequest);

            //call the repo to save using EF6

            repository.SaveTimesheet(result);


            TimesheetImportResult timesheetImportResult = new TimesheetImportResult()
            {
                Success = true,
                Notifications = new List<Notification>()

            };
            return await Task.FromResult(timesheetImportResult).ConfigureAwait(false);
        }
    }
}
