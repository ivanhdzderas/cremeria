using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
    public class SAT_prod: ConnectDB
    {
        public string Code { get; set; }
        public string Description { get; set;}
        public string Start_Vality { get; set; }
        public string End_Vality { get; set; }
        public string Iva_traslate { get; set; }
        public string Isr_traslate { get; set; }
        public string Complement { get; set; }


        public SAT_prod(
           string code,
           string description,
           string start_vality,
           string end_vality,
           string iva_traslate,
           string isr_traslate,
           string complement
           )
        {
            Code = code;
            Description = description;
            Start_Vality = start_vality;
            End_Vality = end_vality;
            Iva_traslate = iva_traslate;
            Isr_traslate = isr_traslate;
            Complement = complement;
        }

        public SAT_prod()
        {

        }

        private SAT_prod build_Sat(MySqlDataReader data)
        {
            SAT_prod item = new SAT_prod(
                data.GetString(0),
                data.GetString(1),
                data.GetString(2),
                data.GetString(3),
                data.GetString(4),
                data.GetString(5),
                data.GetString(6)
                );
            return item;
        }
        public List<SAT_prod> getSat_prodbyDescription(string search) {
            string query = "SELECT c_claveprodserv, descripcion, fechainiciovigencia, fechafinvigencia, incluirivatrasladado, incluiriepstrasladado, complemento FROM zz33_claveprodserv where descripcion like '%" + search + "%'";
            MySqlDataReader data = runQuery(query);
            List<SAT_prod> result = new List<SAT_prod>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    SAT_prod item = build_Sat(data);
                    result.Add(item);
                }
            }
            return result;
        }
        public List<SAT_prod> getSat_prod()
        {
            string query = "SELECT c_claveprodserv, descripcion, fechainiciovigencia, fechafinvigencia, incluirivatrasladado, incluiriepstrasladado, complemento FROM zz33_claveprodserv;";
            MySqlDataReader data = runQuery(query);
            List<SAT_prod> result = new List<SAT_prod>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    SAT_prod item = build_Sat(data);
                    result.Add(item);
                }
            }
            return result;
        }

    }
   
}
