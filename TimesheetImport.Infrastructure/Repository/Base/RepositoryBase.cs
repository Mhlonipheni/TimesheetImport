using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace TimesheetImport.Infrastructure.Repository.Base
{
    public class RepositoryBase
    {
        private readonly IOptions<InfrastructureOptions> options;
        public RepositoryBase(IOptions<InfrastructureOptions> options)
        {
            this.options = options;
        }

        public IDbConnection Connection => new SqlConnection(options.Value.DatabaseConnectionString);
        
    }
}
