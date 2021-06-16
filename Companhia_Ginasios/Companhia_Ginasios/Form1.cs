using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Companhia_Ginasios
{
    public partial class Form1 : Form
    {

        private Database db = new Database();

        public Form1()
        {
            InitializeComponent();
            displayGym(db.DbServer, db.DbName, db.UserName, db.UserPass);
        }

        public void displayGym(string dbServer, string dbName, string userName, string userPass)
        {

            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            try
            {
                CN.Open();
                if (CN.State == ConnectionState.Open)
                {
                    db.Logged = true;
                    SqlCommand sqlcmd = new SqlCommand("SELECT * FROM GymCompany.Ginasio", CN);
                    SqlDataReader reader;
                    reader = sqlcmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ginasios gym = new Ginasios();
                        gym.NIF = reader["NIF"].ToString();
                        gym.Telefone = reader["Telefone"].ToString();
                        gym.Morada = reader["Morada"].ToString();
                        gym.Gestor = reader["Gestor"].ToString();
                        listBox1.Items.Add("NIF: " + gym.NIF + " Phone number: " + gym.Telefone 
                          + " Address: " + gym.Morada + " Manager: " + gym.Gestor);
                    }
                }
            }
            catch (Exception ex)
            {
                db.Logged = false;
                db.Error = "Failed to display data due to the following error: \r\n" + ex.Message;
                MessageBox.Show(db.Error, "An Error Occurred");
            }

            if (CN.State == ConnectionState.Open)
                CN.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String table = db.getTableContent(db.DbServer, db.DbName, db.UserName, db.UserPass);

            if (!db.Logged)
                MessageBox.Show(db.Error, "Operation Failed");
            else
                MessageBox.Show(table);
        }
    }
}
