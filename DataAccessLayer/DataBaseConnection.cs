using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataBaseConnection
    {
        private string _databaseconnectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_samauto;User Id=dbi527531_samauto;Password=samauto123; MultipleActiveResultSets=True; TrustServerCertificate=True";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_databaseconnectionString);
        }
    }
}
