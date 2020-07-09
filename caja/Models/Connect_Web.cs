using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace caja.Models
{
    public class Connect_Web : IDisposable
	{
        MySqlConnection databaseConnection_web = new MySqlConnection(inicial.web_string);
        public void Dispose()
        {
            databaseConnection_web.Close();
        }
        private MySqlDataReader OpenConnection_web(string query)
        {
            if (databaseConnection_web.State == System.Data.ConnectionState.Open)
            {
                databaseConnection_web.Close();
            }
          
            try{
                databaseConnection_web.Open();

                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection_web);
                commandDatabase.CommandTimeout = 60;
                return commandDatabase.ExecuteReader();
            
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public MySqlDataReader runQuery_web(string query)
        {
            try
            {
                return OpenConnection_web(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
