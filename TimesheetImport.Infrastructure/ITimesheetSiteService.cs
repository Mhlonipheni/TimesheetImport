﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimesheetImport.TimesheetModels;

namespace TimesheetImport.Infrastructure
{
    public interface ITimesheetSiteService
    {
        Task<List<TimesheetSite>> GetTimesheetSites();
    }
}