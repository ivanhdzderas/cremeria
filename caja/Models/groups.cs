using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace caja.Models
{
    public class Groups : ConnectDB
    {
        public int Id { get; set; }
        public string Group { get; set; }
        public int Master { get; set; }
        public Groups(
            int id,
            string group,
            int master
            )
        {
            Id = id;
            Group = group;
            Master = master;
        }
        public Groups() { 
        }
        public void createGroup() {
            string query = "INSERT INTO tbagrupo (grupo, master) values ('" + this.Group + "', '" + this.Master + "')";
            Object result = runQuery(query);
        }
        public void deleteGroup() {
            string query = "delete from tbagrupo where id='" + this.Id + "' or master='" + this.Id + "'";
            object result = runQuery(query);
        }
        private Groups buildGroup(MySqlDataReader data) {

            Groups item = new Groups(
                Convert.ToInt32(data.GetString("id")),
                data.GetString("grupo"),
                data.GetInt16("master")
                );
            return item;
        }
        public List<Groups> getGroup()
        {
            string query = "select id, grupo, master from tbagrupo";
            MySqlDataReader data = runQuery(query);
            List<Groups> result = new List<Groups>();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    Groups item = buildGroup(data);
                    result.Add(item);

                }
            }

            return result;
        }

        public List<Groups> getSubgrups(int grupo) {
            string query = "select id, grupo, master from tbagrupo where master='" + grupo.ToString() + "'";
            MySqlDataReader data = runQuery(query);
            List<Groups> result = new List<Groups>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Groups item = buildGroup(data);
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Groups> getGroupsonly()
        {
            string query = "select id, grupo, master from tbagrupo where master=''";
            MySqlDataReader data = runQuery(query);
            List<Groups> result = new List<Groups>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Groups item = buildGroup(data);
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Groups> getGroupbyId(string id)
        {
            string query = "select id, grupo, master from tbagrupo where id='" + id + "'";
            MySqlDataReader data = runQuery(query);
            List<Groups> result = new List<Groups>();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    Groups item = buildGroup(data);
                    result.Add(item);
                }
            }
            return result;
        }
    }
   
}
