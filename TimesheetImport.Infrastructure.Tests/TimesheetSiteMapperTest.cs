using System.Reflection.PortableExecutable;
using TimesheetImport.Infrastructure.Repository.ModelMappings;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TimesheetImport.Infrastructure.Tests;

[TestClass]
public class TimesheetSiteMapperTest
{
    [TestMethod]

    //[DataRow("2023-11-27 00:00:00", 12, 0, 22, 0, 8.5)]
    //[DataRow("2023-10-24 00:00:00", 4, 0, 13, 0, 8)]
    //[DataRow("2023-10-24 00:00:00", 5, 0, 14, 0, 8)]
    //[DataRow("2023-10-24 00:00:00", 13, 0, 22, 0, 8)]
    //[DataRow("2023-10-24 00:00:00", 18, 0, 6, 0, 8)]
    //[DataRow("2023-11-27 00:00:00", 4, 0, 19, 0, 13)]
    [DataRow("2023-11-27 12:00:00", 12, 0, 21, 50,12,0, 8.83)]
    //[DataRow("2023-11-27 00:00:00", 6, 0, 17, 0, 7.83)]
    [DataRow("2023-11-29 00:00:00", 6, 0, 15, 10,6,0, 8.17)]
    [DataRow("2023-11-27 00:00:00", 12, 0, 22, 0, 17, 0, 5)]
    [DataRow("2023-11-28 00:00:00", 3, 0, 12, 0, 3, 0, 8)]
    public void TestCalculateHours(string shiftDate, int shiftStartHour, int shiftStartMinute, int shiftEndHour, int shiftEndMinute, int workStartHour, int workStartMinute, double workedHours)
    {
        var shiftDateTime = DateTime.Parse(shiftDate);
        var shiftStartTime = new TimeSpan(shiftStartHour, shiftStartMinute, 0);
        var shiftEndTime = new TimeSpan(shiftEndHour, shiftEndMinute, 0); 
        var workStartTime = new TimeSpan(workStartHour, workStartMinute, 0);
        var sd = shiftDateTime.Date.Add(shiftStartTime);
        var endDateTime = shiftDateTime.Date.Add(shiftEndTime);
        var actualWorkStartDateTime = shiftDateTime.Date.Add(workStartTime);
        if (sd > endDateTime)
        {
            endDateTime = endDateTime.AddDays(1);
        }
        
        var result = TimesheetSiteMapper.CalculateHours(sd, actualWorkStartDateTime,endDateTime, 18,6, workedHours);
        Assert.IsTrue(result.NormalHours + result.NightShiftHours == workedHours);
        Assert.IsTrue(result.NightShiftHours >= 0);
        Assert.IsTrue(result.NormalHours >= 0);
    }
}