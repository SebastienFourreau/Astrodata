using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DatabaseNamespace;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    class Object
    {
        public Database singleton = Database.getInstance();
        public MySqlConnection dao;

        public Object()
        {
            dao = singleton.db;
        }

        public List<string> getAllType()
        {
            MySqlCommand command = new MySqlCommand("SELECT name FROM object_type", dao);
            
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                List<string> object_type = new List<string>();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        object_type.Add(reader.GetValue(i).ToString());
                }

                return object_type;
            }
        }
    }
}
