using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DatabaseNamespace
{
    public sealed class Database
    {
        public MySqlConnection db = null;

        private volatile static Database singleTonObject = null;
        private static readonly object padlock = new object();

        private const string OPT_SERVER = "localhost";
        private const string OPT_DATABASE = "csharp";
        private const string OPT_UID = "root";
        private const string OPT_PASSWORD = "";

        private Database()
        {
            this.connect();
        }

        private string getConnectionString()
        {
            return "SERVER=" + OPT_SERVER + ";" + "DATABASE=" + OPT_DATABASE + ";" + "UID=" + OPT_UID + ";" + "PASSWORD=" + OPT_PASSWORD;
        }

        public void connect()
        {
            db = new MySqlConnection(this.getConnectionString());

            if (db != null)
                db.Close();

            try
            {
                db.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Close the connection.
        /// </summary>
        public void Close()
        {
            if(db != null)
                db.Close();
        }
        
        public static Database getInstance()
        {
            if(singleTonObject == null)
            {
                 lock(padlock)
                 {
                      if(singleTonObject == null)
                      {
                           singleTonObject = new Database();
                      }
                 }
            }

            return singleTonObject;
        }

        ~Database()
        {
            this.Close();
        }
    }
}
