using TimesheetImport.Infrastructure.Repository.ModelMappings;

namespace TimesheetImport.Infrastructure.Tests;

[TestClass]
public class TimesheetSiteMapperTest
{
    [TestMethod]

    [DataRow("2023-11-27 12:30:00", 8.5)]
    [DataRow("2023-11-27 12:00:00", 9)]
    [DataRow("2023-11-27 06:00:00", 9)]
    [DataRow("2023-11-27 18:00:00", 9)]
    [DataRow("2023-11-27 04:00:00", 9)]
    public void TestCalculateHours(string startDateTime, double workedHours)
    {
        var startWorkDateTime = DateTime.Parse(startDateTime);
        var endDateTime = startWorkDateTime.AddHours(workedHours);
        var result = TimesheetSiteMapper.CalculateHours(startWorkDateTime, endDateTime, 18,6, workedHours);
        Assert.IsTrue(result.NormalHours + result.NightShiftHours == workedHours);
    }
}