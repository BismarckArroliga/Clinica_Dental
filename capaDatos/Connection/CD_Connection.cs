using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace capaDatos
{
    public class CD_Connection
    {
        private readonly string connectionString;
        public CD_Connection()
        {
            connectionString = "Data Source=(local);Initial Catalog=BD_Clinica;Integrated Security=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
