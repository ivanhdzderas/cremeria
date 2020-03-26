using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
    public class Unidad_Sat:ConnectDB
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Simbol { get; set; }
        public Unidad_Sat(
            string code,
            string name, 
            string description,
            string start,
            string end, 
            string simbol
            )
        {
            Code = code;
            Name = name;
            Description = description;
            Start = start;
            End = end;
            Simbol = simbol;
        }
        public Unidad_Sat()
        {
           
        
        

        }

        private Unidad_Sat build_Sat(MySqlDataReader data)
        {
            Unidad_Sat item = new Unidad_Sat(
                   data.GetString(0),
                   data.GetString(1),
                   data.GetString(2),
                   data.GetString(3),
                   data.GetString(4),
                   data.GetString(5)
                   );
            return item;
        }

        public List<Unidad_Sat> getUnidadSatByDescripton(string serach)
        {
            string query = "SELECT c_claveunidad, nombre, descripcion, fechainiciovigencia, fechafinvigencia, simbolo FROM zz33_claveunidad where descripcion like '%" + serach + "%';";
            MySqlDataReader data = runQuery(query);
            List<Unidad_Sat> result = new List<Unidad_Sat>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Unidad_Sat item = build_Sat(data);
                    result.Add(item);
                }
            }
            return result;
        }
        public List<Unidad_Sat> getUnidadSat()
        {
            string query = "SELECT c_claveunidad, nombre, descripcion, fechainiciovigencia, fechafinvigencia, simbolo FROM zz33_claveunidad;";
            MySqlDataReader data = runQuery(query);
            List<Unidad_Sat> result = new List<Unidad_Sat>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Unidad_Sat item = build_Sat(data);
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
