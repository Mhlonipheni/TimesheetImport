﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TimesheetImport.TimesheetModels;

namespace TimesheetImport.Infrastructure
{
    public interface ITimesheetSiteService
    {
        Task<List<TimesheetSite>> GetTimesheetSites();
        Task ImportToTimesheets(FileUploadRequest fileUploadRequest);
    }
}
