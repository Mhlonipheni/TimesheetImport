namespace TimesheetImport.Infrastructure
{
    public class InfrastructureOptions
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string RMSConnectionString { get; set; }
    }
}
