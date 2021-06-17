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

        public void DbLogin(string dbServer, string dbName, string userName, string userPass)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                       "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    logged = true;
                    error = "";
                }
            }
            catch (Exception ex)
            {
                logged = false;
                error = "Failed to login due to the following error: \r\n" + ex.Message;
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        public string getTableContent(string dbServer, string dbName, string userName, string userPass)
        {
            string str = "";

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    logged = true;
                    int cnt = 1;
                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM GymCompany.Ginasio", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        str += reader.GetInt32(reader.GetOrdinal("NIF")) + ", ";
                        str += reader.GetInt32(reader.GetOrdinal("Telefone")) + ", ";
                        str += reader.GetString(reader.GetOrdinal("Morada")) + ", ";
                        str += reader.GetString(reader.GetOrdinal("Gestor"));
                        str += "\n";
                        cnt += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                logged = false;
                error = "Failed to grab data due to the following error: \r\n" + ex.Message;
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
                
            return str;
        }

       
    }
}
