using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetImport.TimesheetModels
{
    public class FileUploadRequest
    {
        public string SiteId { get; set; }
       public  MemoryStream File { get; set; }
    }
}
