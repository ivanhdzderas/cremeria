using System;
using MySql.Data.MySqlClient;

namespace caja.Models
{
    public abstract class ConnectDB : IDisposable
    {
        MySqlConnection databaseConnection = new MySqlConnection(inicial.connectionString);
        public void Dispose() {
            databaseConnection.Close();
        }
        private MySqlDataReader OpenConnection(string query) {

            

                if (databaseConnection.State == System.Data.ConnectionState.Open)
                {
                    databaseConnection.Close();
                }
            databaseConnection.Open();

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            
            commandDatabase.CommandTimeout = 60;
            
            return commandDatabase.ExecuteReader();
        }

        public MySqlDataReader runQuery(string query) {
            try
            {
                return OpenConnection(query);
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        
        }

    }


}
