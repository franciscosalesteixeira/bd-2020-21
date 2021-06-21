using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Companhia_Ginasios
{
    class Database
    {

        private string dbServer = "tcp:mednat.ieeta.pt\\SQLSERVER,8101";
        private string dbName = "p3g9";
        private string userName = "p3g9";
        private string userPass = "1208877445@BD!";
        private string constring;
        private string error;
        private bool logged;

        public String DbServer
        {
            get { return this.dbServer; }
            set { this.dbServer = value; }
        }

        public String DbName
        {
            get { return this.dbName; }
            set { this.dbName = value; }
        }

        public String UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public String UserPass
        {
            get { return this.userPass; }
            set { this.userPass = value; }
        }

        public String Error
        {
            get { return this.error; }
            set { this.error = value; }
        }

        public String getConstring()
        {
            constring = "Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass;

            return constring;
        }

        public bool Logged
        {
            get { return this.logged; }
            set { this.logged = value; }
        }    
    }
}
