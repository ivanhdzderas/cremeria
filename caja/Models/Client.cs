using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace caja.Models
{
    public class Client : ConnectDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public string Street { get; set; }
        public string Ext_number { get; set; }
        public string Int_number { get; set; }
        public string Col { get; set; }
        public string Cp { get; set; }
        public string State { get; set; }
        public string Muni { get; set; }
        public string Tel { get; set; }
        public string Note { get; set; }
        public string Email { get; set; }
        public Client(
            int id,
            string name,
            string rfc,
            string street,
            string ext_number, 
            string int_numbre,
            string col, 
            string cp,
            string state,
            string muni, 
            string tel,
            string note, 
            string email
            ) {
            Id = id;
            Name = name;
            RFC = rfc;
            Street = street;
            Ext_number = ext_number;
            Int_number = int_numbre;
            Col = col;
            Cp = cp;
            State = state;
            Muni = muni;
            Tel = tel;
            Note = note;
            Email = email;
        }

        public Client() { 
        }

        public void createClient() {
            string query = "insert into tbaclientes (nombre, RFC, calle,num_ext, num_int, colonia, cp, estado, municipio, telefono, notas, email)";
            query += " values (";
            query += "'" + this.Name + "', ";
            query += "'" + this.RFC + "', ";
            query += "'" + this.Street + "', ";
            query += "'" + this.Ext_number + "', ";
            query += "'" + this.Int_number + "', ";
            query += "'" + this.Col + "', ";
            query += "'" + this.Cp + "', ";
            query += "'" + this.State + "', ";
            query += "'" + this.Muni + "', ";
            query += "'" + this.Tel + "', ";
            query += "'" + this.Note + "', ";
            query += "'" + this.Email + "'";
            query += ")";
            object result = runQuery(query);
        }

        public void saveClient() {
            string query = "update tbaclientes set ";
            query += "nombre='" + this.Name + "',";
            query += "RFC='" + this.RFC + "', ";
            query += "calle='" + this.Street + "',";
            query += "num_ext='" + this.Ext_number + "',";
            query += "num_int='" + this.Int_number +"',";
            query += "colonia='" + this.Col +"',";
            query += "cp='" + this.Cp + "',";
            query += "estado='" + this.State +"',";
            query += "municipio='" + this.Muni +"',";
            query += "telefono='" + this.Tel +"',";
            query += "notas='" + this.Note +"',";
            query += "email='" + this.Email +"' ";
            query += "where id='" + this.Id + "'";
            object result = runQuery(query);
        }
        private Client buildClient(MySqlDataReader data) {
            Client item = new Client(
                data.GetInt16("id"),
                data.GetString("nombre"),
                data.GetString("RFC"),
                data.GetString("calle"),
                data.GetString("num_ext"),
                data.GetString("num_int"),
                data.GetString("colonia"),
                data.GetString("cp"),
                data.GetString("estado"),
                data.GetString("municipio"),
                data.GetString("telefono"),
                data.GetString("notas"),
                data.GetString("email")
                );
            return item;
        }
        private string maq_query = "select id, nombre, RFC, calle, num_ext, num_int, colonia, cp,estado, municipio, telefono, notas, email from tbaclientes";
        public List<Client> getClients() {
            string query = maq_query;
            MySqlDataReader data = runQuery(query);
            List<Client> result = new List<Client>();
            if (data.HasRows) {
                while (data.Read()) {
                    Client item = buildClient(data);
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Client> getClientbyId(int id) {
            string query = maq_query + " where id='" + id.ToString() + "'";
            MySqlDataReader data = runQuery(query);
            List<Client> result = new List<Client>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Client item = buildClient(data);
                    result.Add(item);
                }
            }
            return result;
        }
        public List<Client> getClientbyName(string nombre)
        {
            string query = maq_query + " where nombre like '%" + nombre + "%'";
            MySqlDataReader data = runQuery(query);
            List<Client> result = new List<Client>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Client item = buildClient(data);
                    result.Add(item);
                }
            }
            return result;
        }


        public List<Client> getClientbyRFC(string rfc)
        {
            string query = maq_query + " where RFC like '%" + rfc + "%'";
            MySqlDataReader data = runQuery(query);
            List<Client> result = new List<Client>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Client item = buildClient(data);
                    result.Add(item);
                }
            }
            return result;
        }


    }
}
