using MiApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiApi.Connection
{
    public class ConnectionBD
    {
        public IDbConnection db { get; set; }

        public ConnectionBD()
        {
            db = new SqlConnection(AppConfiguration.Connection);
        }
    }
}
