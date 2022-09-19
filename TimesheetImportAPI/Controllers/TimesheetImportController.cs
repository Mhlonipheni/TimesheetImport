using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
