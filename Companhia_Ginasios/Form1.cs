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
            DisplayGym(db.DbServer, db.DbName, db.UserName, db.UserPass);
        }

        private void DisplayGym(string dbServer, string dbName, string userName, string userPass)
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

        private void AddGym(string dbServer, string dbName, string userName, string userPass, Ginasios gym)
        {
            SqlConnection CN = new SqlConnection("Data Source = " + dbServer + " ;" + "Initial Catalog = " + dbName +
                                                        "; uid = " + userName + ";" + "password = " + userPass);

            db.Logged = true;
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO GymCompany.Ginasio(NIF, Telefone, Morada, Gestor) VALUES(@nif, @telefone, @morada, @gestor)");
            sqlcmd.Parameters.Clear();
            sqlcmd.Parameters.AddWithValue("@nif", gym.NIF);
            sqlcmd.Parameters.AddWithValue("@telefone", gym.Telefone);
            sqlcmd.Parameters.AddWithValue("@morada", gym.Morada);
            sqlcmd.Parameters.AddWithValue("@gestor", gym.Gestor);
            sqlcmd.Connection = CN;

            try
            {
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add gym in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                CN.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String table = db.getTableContent(db.DbServer, db.DbName, db.UserName, db.UserPass);

            if (!db.Logged)
                MessageBox.Show(db.Error, "Operation Failed");
            else
                MessageBox.Show(table);
        }

        private void AddBttn_Click(object sender, EventArgs e)
        {
            ClearFields();
            listBox1.Visible = false;
            listBox1.Enabled = false;
            panel1.Enabled = true;
            panel1.Visible = true;
            button1.Visible = false;
            button1.Enabled = false;
        }

        private void ListBttn_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Enabled = true;
            panel1.Visible = false;
            panel1.Enabled = false;
            button1.Visible = true;
            button1.Enabled = true;
        }

        private void SaveBttn_Click(object sender, EventArgs e)
        {
            Ginasios gym = new Ginasios();
            try
            {
                gym.NIF = txtNIF.Text;
                gym.Telefone = txtPhone.Text;
                gym.Morada = txtAddress.Text;
                gym.Gestor = txtManager.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            AddGym(db.DbServer, db.DbName, db.UserName, db.UserPass, gym);
            listBox1.Visible = true;
            listBox1.Enabled = true;
            panel1.Enabled = false;
            panel1.Visible = false;
            button1.Visible = true;
            button1.Enabled = true;
        }

        public void ClearFields()
        {
            txtAddress.Text = "";
            txtManager.Text = "";
            txtNIF.Text = "";
            txtPhone.Text = "";
        }
    }
}
