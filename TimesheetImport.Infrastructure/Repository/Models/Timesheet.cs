using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimesheetImport.Infrastructure.Repository.Models
{
    public class Timesheet
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
