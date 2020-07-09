using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace caja.Models
{
    public class Marcas:ConnectDB
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public Marcas(
            int id,
            string marca 
            )
        {
            Id = id;
            Marca = marca;
        }
        public Marcas()
        {
        }

        public void createMarca() {
            string query = "INSERT INTO tbamarca (marca) values ('" + this.Marca + "')";
            object result = runQuery(query);
            Forms.intercambios intercambio = new Forms.intercambios();
            if (intercambio.test_red())
            {
                Connect_Web conector_web = new Connect_Web();
                conector_web.runQuery_web(query);
            }
        }
        private Marcas buildMarcas(MySqlDataReader data) {
            Marcas item = new Marcas(
                 data.GetInt32(0),
                 data.GetString("marca")
                );
            return item;
        }
        public List<Marcas> getMarcas() {
            string query = "select id, marca from tbamarca";
            MySqlDataReader data = runQuery(query);
            List<Marcas> result = new List<Marcas>();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    Marcas item = buildMarcas(data);
                    result.Add(item);

                }
            }

            return result;
        }
    }
}
