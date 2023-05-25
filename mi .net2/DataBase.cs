using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mi.net2
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=FEER;Initial Catalog=MediTrack;Integrated Security=True");

        public void Open_Connection()
        {

            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void Close_Connection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
